**Steps for setting up the Kafka Docker image**

  1. Install Docker
  2. Copy the *docker-compose.yml* file to local directory
  3. Navigate to the directory and Run the command **docker-compose up --detach**

Please note that as specified in the yml file, *default port for zookeeper and kafka will be **2181** and **9092*** respectively. In case, you want to use some other ports, please change the same before running the docker-compose up command.


**Steps for setting up the Console Application for Consumer**

  1. Clone the *kafka-console-app* repo and open the solution
  
Note : In */services/KafkaConsumerService.cs*, there is a max time out of 30 seconds set for the consumer. If the consumer doesn't receive any message for a span of 30 seconds, it will come out of the loop.


**Steps for setting up the Kafka Producer Application**

  1. Clone the *kafka-producer-api* repo and open the solution
  2. Run the application
  3. User can perform Post call to endpoint *http://localhost:5000/api/kafkaproducer/produce* having the *topic* as URL parameter and a JsonArray of Car details as the request          body (For request body, refer to *kafka-console-app/messages/car.json*).


**Steps to test the entire flow**

  1. Make sure that Kafka and zookeeper containers are up and running
  2. Run the *kafka-producer-api* application
  3. Open Postman and prepare a Post call with all the required details (topic and request body)
  4. Run the *kafka-console-app* application
  5. Send the message from Postman and observe the Terminal window of *kafka-console-app*
  6. Once all the messages are consumed, and the time out period is over, comparison between produced and Consumed messages will be shown.
  7. User can play around with the Json file to test positive and negative scenarios.
