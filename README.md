# EventDrivenArchitecture
### Event Drive Architecture studies

* In Demo 01, we have a simple idea of how to use events without any dependency of Kafka, RabbitMQ or other provider. It follows some concepts of DDD (aggregate root, bounded and shared context).
* In Demo 02, we have a docker-compose to set up the Zookeeper using the confluentinc image in port 2181 (default) and mapping to 22181. We have also a Kafka immage from confluentinc, dependent on zookeeper. We also have kafka-ui (an open source project from provectus labs) an IDE to work with Kafka.
* In Demo 03 - TODO
