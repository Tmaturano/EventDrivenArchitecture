using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text.Json;
using ThiagoStore.SharedContext.Events;
using ThiagoStore.SharedContext.ExternalServices;

namespace ThiagoStore.Order.Infra.ExternalServices
{
    public class KafkaEventService : IEventService
    {
        public void Queue(IDomainEvent evt)
        {
            var config = LoadConfig();
            var value = JsonSerializer.Serialize(evt);
            Produce("payments", evt.Id.ToString(), value, config);
        }

        private static ClientConfig LoadConfig()
        {
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

        private static void Produce(string topic, string key, string value, ClientConfig config)
        {
            using var producer = new ProducerBuilder<string, string>(config).Build();
            producer.Produce(topic, new Message<string, string> { Key = key, Value = value },
                (deliveryReport) =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                        throw new Exception(deliveryReport.Error.Reason);
                });
            producer.Flush(TimeSpan.FromSeconds(10));
        }
    }
}
