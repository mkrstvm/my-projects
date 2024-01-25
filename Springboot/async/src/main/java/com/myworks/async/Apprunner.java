package com.myworks.async;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.util.concurrent.CompletableFuture;


public class Apprunner implements CommandLineRunner {
    private static final Logger logger = LoggerFactory.getLogger(Apprunner.class);

    private final GitHubLookUpService _service;
    @Override
    public void run(String... args) throws Exception {

        CompletableFuture<User> page1 = _service.findUsers("PivotalSoftware");
        CompletableFuture<User> page2 = _service.findUsers("CloudFoundry");
        CompletableFuture<User> page3 = _service.findUsers("Spring-Projects");

        CompletableFuture.allOf(page1,page2,page3).join();
        logger.info("--> " + page1.get());
        logger.info("--> " + page2.get());
        logger.info("--> " + page3.get());
    }

    public Apprunner(GitHubLookUpService service)
    {
        _service = service;

    }
}
