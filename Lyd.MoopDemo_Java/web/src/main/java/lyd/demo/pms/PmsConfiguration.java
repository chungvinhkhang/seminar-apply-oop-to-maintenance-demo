package lyd.demo.pms;

import lyd.demo.pmscore.PmsApp;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
public class PmsConfiguration {

    @Bean
    @Scope(value = "singleton")
    public PmsApp pmsApp() {
        PmsApp pmsAppInstance = new PmsApp();
        pmsAppInstance.initGuests();
        return pmsAppInstance;
    }
}
