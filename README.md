# kafka-project


What is Apache Kafka?

We are using Apache Kafka as middleware between our microservices. When we need to communicate between microservices to create asynchronous, loosely coupled communication, we can use Apache Kafka or its alternatives.

![Captura de tela 2025-03-07 225046](https://github.com/user-attachments/assets/5796a56d-ce0f-4c9f-a60d-4d86abaa5f14)

When we use synchronous communication between microservices, there is no message broker in the middle. Instead, microservice A sends a direct request to microservice B and waits for a response before proceeding.

In this case, microservice A acts as a client, and microservice B acts as a server. This approach ensures immediate responses and is useful when real-time data consistency is required. However, it creates tight coupling, meaning microservice A must be aware of microservice B's availability, which can impact scalability and fault tolerance.

![Captura de tela 2025-03-07 225640](https://github.com/user-attachments/assets/a05ac42c-9364-408d-951b-082756887584)

When we use asynchronous communication between microservices, there is a message broker in the middle. You are not sending requests directly to microservice B; instead, you are producing data to a message broker. Another microservice then consumes data from the message broker.

So, microservice A acts as a producer, and microservice B acts as a consumer. This helps create event-based asynchronous communication, meaning microservice A does not know about microservice B, and microservice B does not know about microservice A. This approach improves maintainability, scalability, and extensibility without affecting microservice B.

Zookeeper is the manager of our Apache Kafka brokers. It acts as a central coordinator that manages broker information, topic metadata, and more. Zookeeper helps us interact with Apache Kafka by notifying it when brokers go down, when topics are created or removed, and by storing essential metadata for our topics.

--------------------------------------
cd project
cd app

docker-compose up -d
![Captura de tela 2025-03-07 233354](https://github.com/user-attachments/assets/31819c91-7c80-4e7d-a485-ed8fd619b16a)

What type of components do we have in our apache kafka
We have the producers, message , broker , kafka cluster, consukmer.

The producers will be microservices, and the consumers will also be microservices.

A producer is a service responsible for generating data. This data is referred to as a message. So, we produce messages, and the Kafka broker acts as a storage system for these messages. However, Kafka is not a traditional database—it only behaves like one. Instead, it uses a special mechanism to store messages in a binary format.

![image](https://github.com/user-attachments/assets/f3ef3293-d574-4dc4-ba5a-55c2bc9e631c)


A broker is essentially a server, but in Kafka, it plays a more significant role. Kafka brokers can communicate with each other and share information about the cluster. The Kafka cluster acts as a logical abstraction over multiple brokers, managing the distribution of data and ensuring fault tolerance.

The producer does not know about the consumer, and the consumer does not know about the producer. However, the producer can generate and send data, while the consumer can receive and process that data.
