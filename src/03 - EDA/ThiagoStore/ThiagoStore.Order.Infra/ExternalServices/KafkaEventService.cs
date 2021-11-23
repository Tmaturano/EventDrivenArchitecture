using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ThiagoStore.SharedContext.Events;
using ThiagoStore.SharedContext.ExternalServices;

namespace ThiagoStore.Order.Infra.ExternalServices
{
    public class KafkaEventService : IEventService
    {
        public async Task Queue(IDomainEvent evt, string topic)
        {
            var config = LoadConfig();
            var value = JsonSerializer.Serialize(evt);
            //await CreateTopicIfNotExist(topic, numberPartitions: 1, replicationFactor: 3, config);
            Produce(topic, evt.Id.ToString(), value, config);
        }

        private ClientConfig LoadConfig()
        {
            // This config should be external and not in plain text like in this example
            var cloudConfig = new Dictionary<string, string>
            {
                {"bootstrap.servers", "pkc-lzvrd.us-west4.gcp.confluent.cloud:9092"},
                {"security.protocol", "SASL_SSL"},
                {"sasl.mechanisms", "PLAIN"},
                {"sasl.username", "HIDDEN"}, //change with the values from the config file from confluent
                {"sasl.password", "HIDDEN"} //change with the values from the config file from confluent
            };

            return new ClientConfig(cloudConfig);            
        }

        private async Task CreateTopicIfNotExist(string name, int numberPartitions, short replicationFactor, ClientConfig cloudConfig)
        {
            using var adminClient = new AdminClientBuilder(cloudConfig).Build();
            try
            {
                await adminClient.CreateTopicsAsync(new List<TopicSpecification> {
                        new TopicSpecification
                        {
                            Name = name,
                            NumPartitions = numberPartitions,
                            ReplicationFactor = replicationFactor
                        } });
            }
            catch (CreateTopicsException e)
            {
                if (e.Results[0].Error.Code != ErrorCode.TopicAlreadyExists)
                {
                    Console.WriteLine($"An error occured creating topic {name}: {e.Results[0].Error.Reason}");
                }
                else
                {
                    Console.WriteLine("Topic already exists");
                }
            }
        }

        private void Produce(string topic, string key, string value, ClientConfig config)
        {
            using var producer = new ProducerBuilder<string, string>(config).Build();
            producer.Produce(topic, new Message<string, string> { Key = key, Value = value },
                (deliveryReport) =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                        throw new Exception(deliveryReport.Error.Reason);
                });
            producer.Flush(TimeSpan.FromSeconds(10));

            Console.WriteLine($"Message sent to topic {topic}");
        }
    }
}
