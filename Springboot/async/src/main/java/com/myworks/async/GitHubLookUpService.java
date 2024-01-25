package com.myworks.async;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.web.client.RestTemplateBuilder;
import org.springframework.scheduling.annotation.Async;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.util.concurrent.CompletableFuture;

@Service
public class GitHubLookUpService {

    public static final Logger _logger = LoggerFactory.getLogger(GitHubLookUpService.class);
    private final RestTemplate _template;
    public GitHubLookUpService(RestTemplateBuilder templateBuilder)
    {
        _template = templateBuilder.build();
    }

    @Async
    public CompletableFuture<User> findUsers(String user) throws InterruptedException {
        _logger.info("looking up " + user);

        String url = String.format("https://api.github.com/users/%s", user);
        User results = _template.getForObject(url,User.class);
        Thread.sleep(1000);
        return  CompletableFuture.completedFuture(results);
    }

}
