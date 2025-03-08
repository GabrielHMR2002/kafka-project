using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Confluent.Kafka;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController (EmployeeDbContext dbContext, ILogger<EmployeesController> logger)
    {

        private readonly ILogger<EmployeesController> _logger = logger;
        private readonly EmployeeDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task <IEnumerable<Employee>> GetEmployees()
        {
            _logger.LogInformation("Requesting all employees.");
            return await _dbContext.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(string name, string surname)
        {
            var employee = new Employee(Guid.NewGuid(), name, surname);
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            //creating a message 
            var message = new Message<string, string>()
            {
                Key = employee.Id.ToString(),
                Value = JsonSerializer.Serialize(employee)
            };

            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
                Acks = Acks.All
            };

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                await producer.ProduceAsync("employeeTopic", message);
            }
            return CreatedAtAction(nameof(CreateEmployee), new { id = employee.Id }, employee);
        }
    }
}
