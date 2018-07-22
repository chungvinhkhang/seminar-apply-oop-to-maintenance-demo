package lyd.demo.pms;

import lyd.demo.pmscore.PmsApp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class ManageGuestController {

    private PmsApp pmsApp;

    @GetMapping("/")
    public String manageGuest(Model model) {
        model.addAttribute("searchKey", "");
        model.addAttribute("guests", this.pmsApp.getGuests());
        return "manageguest";
    }

    @GetMapping("/search")
    public String searchGuest(@RequestParam("searchKey") String searchKey, Model model) {
        model.addAttribute("searchKey", searchKey);
        model.addAttribute("guests", this.pmsApp.searchGuests(searchKey));
        return "manageguest";
    }

    @Autowired
    public void setPmsApp(PmsApp pmsApp) {
        this.pmsApp = pmsApp;
    }
}
