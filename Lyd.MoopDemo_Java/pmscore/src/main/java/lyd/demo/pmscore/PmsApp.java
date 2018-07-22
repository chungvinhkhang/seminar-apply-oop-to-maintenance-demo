package lyd.demo.pmscore;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class PmsApp {
    private List<Guest> guests;
    private GuestCodeGenerator guestCodeGenerator;

    public PmsApp(){
        guests = new ArrayList<>();
        guestCodeGenerator = new GuestCodeGeneratorImpl();
    }

    public List<Guest> initGuests(){
        this.guests.clear();
        this.addGuest("Chung Vinh Khang", "97 Vo Van Tan", "01227xxx5908", Gender.MALE);
        this.addGuest("Tran Dang Khoa", "98 Vo Van Tan", "01227xxx1991", Gender.MALE);
        this.addGuest("Vo Hoang Cham", "99 Vo Van Tan", "0122xxx1999", Gender.FEMALE);
        this.addGuest("Pham Thien An", "96 Vo Van Tan", "0112xxx1918", Gender.FEMALE);
        return this.guests;
    }

    public List<Guest> getGuests(){
        return this.guests;
    }

    public List<Guest> searchGuests(String searchKey){
        return this.guests.stream()
                .filter(p -> p.getGuestName().contains(searchKey))
                .collect(Collectors.toList());
    }

    private Guest addGuest(String guestName, String address, String phone, Gender gender){
        Guest guest = new Guest(guestName, address, phone, gender);
        guest.generateGuestCode(this.guestCodeGenerator);
        this.guests.add(guest);
        return guest;
    }
}
