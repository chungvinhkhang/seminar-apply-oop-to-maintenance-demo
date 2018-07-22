package lyd.demo.pmscore;

public class Guest {
    private String guestName;
    private String guestCode;
    private String address;
    private String phone;
    private Gender gender;

    public Guest(String guestName, String address, String phone, Gender gender) {
        this.guestName = guestName;
        this.address = address;
        this.phone = phone;
        this.gender = gender;
    }

    public String generateGuestCode(GuestCodeGenerator generator){
        this.guestCode = generator.Generate(this);
        return guestCode;
    }

    public String getGuestName() {

        return guestName;
    }

    public void setGuestName(String guestName) {
        this.guestName = guestName;
    }

    public String getGuestCode() {
        return guestCode;
    }

    public void setGuestCode(String guestCode) {
        this.guestCode = guestCode;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public Gender getGender() {
        return gender;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
    }
}
