package com.example.cloud.stream;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.stream.annotation.EnableBinding;
import org.springframework.cloud.stream.annotation.StreamListener;
import org.springframework.cloud.stream.messaging.Sink;

@SpringBootApplication
@EnableBinding(Sink.class)
public class SpringbootConsumerApplication {

    @StreamListener("input")
    public void consumeMessage(Book book)
    {

    }

    private Logger logger = LoggerFactory.getLogger(SpringbootConsumerApplication.class);

    public static void main(String args)
    {
        SpringApplication.run(SpringbootConsumerApplication.class, args);
    }

}
