package lyd.demo.pmscore;

public class GuestCodeGeneratorImpl implements GuestCodeGenerator {

    @Override
    public String Generate(Guest guest) {
        int spaceLastIndexOfGuestName = guest.getGuestName().lastIndexOf(' ');
        String firstCharOfGuestLastName = guest.getGuestName().substring(spaceLastIndexOfGuestName + 1, spaceLastIndexOfGuestName + 2);
        String threeLastCharOfGuestPhone = guest.getPhone().substring(guest.getPhone().length() - 3);
        String code = String.format("%s%s",firstCharOfGuestLastName,threeLastCharOfGuestPhone);
        return code;
    }
}
