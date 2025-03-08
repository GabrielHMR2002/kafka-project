# kafka-project


What is Apache Kafka?

We are using Apache Kafka as middleware between our microservices. When we need to communicate between microservices to create asynchronous, loosely coupled communication, we can use Apache Kafka or its alternatives.

When we use synchronous communication between microservices, there is no message broker in the middle. Instead, microservice A sends a direct request to microservice B and waits for a response before proceeding.

In this case, microservice A acts as a client, and microservice B acts as a server. This approach ensures immediate responses and is useful when real-time data consistency is required. However, it creates tight coupling, meaning microservice A must be aware of microservice B's availability, which can impact scalability and fault tolerance.

When we use asynchronous communication between microservices, there is a message broker in the middle. You are not sending requests directly to microservice B; instead, you are producing data to a message broker. Another microservice then consumes data from the message broker.

So, microservice A acts as a producer, and microservice B acts as a consumer. This helps create event-based asynchronous communication, meaning microservice A does not know about microservice B, and microservice B does not know about microservice A. This approach improves maintainability, scalability, and extensibility without affecting microservice B.

Zookeeper is the manager of our Apache Kafka brokers. It acts as a central coordinator that manages broker information, topic metadata, and more. Zookeeper helps us interact with Apache Kafka by notifying it when brokers go down, when topics are created or removed, and by storing essential metadata for our topics.
