# EventDrivenArchitecture
### Event Drive Architecture studies

**In Demo 01**, we have a simple idea of how to use events without any dependency of Kafka, RabbitMQ or other provider. It follows some concepts of DDD (aggregate root, bounded and shared context).

**In Demo 02**, we have a docker-compose to set up the Zookeeper using the confluentinc image in port 2181 (default) and mapping to 22181. We have also a Kafka immage from confluentinc, dependent on zookeeper. We also have kafka-ui (an open source project from provectus labs) an IDE to work with Kafka. 

To test it: run in a terminal **docker compose up -d**.

After all the containers started, you can open the web browser and navigates to http://localhost:8080/ to see the kafka ui.

https://www.confluent.io/get-started/ 

Records, Topics and Partitions, three fundamental pieces to send and receive messages in kafka.

- Record: Key, Value, Timestamp, where Key and Value can be anything.
- Topic: group of records. Stored in Brokers and managed by Zookeeper. 
    * Two strategies to store a topic: Delete/Compaction.
        * Delete: Set a max value in bytes and the topic will be deleting the old messages by size or time.
        * Compaction: Upsert approach. If don't exist, it creates, otherwise, updates.
- Partitions: allow the topic to exist in multiple brokers. The same message doesn't exists in N partitions. 
  * Replicated Partitions:
    * Same partition in different brokers. E.g. Partition A in Broker A and the same Partition A in Broker B. If something goes wrong with one broker, you'll have another one to handle the message.
- Producer: Who creates the event.
- Consumer: Who consumes the event.
- Streaming: Process the events, one by one, in the order they arrive in the system (like a video streaming), in real time.

**In Demo 03** - TODO
