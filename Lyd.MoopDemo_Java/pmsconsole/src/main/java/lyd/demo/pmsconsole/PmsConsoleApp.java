package lyd.demo.pmsconsole;

import lyd.demo.pmscore.Guest;
import lyd.demo.pmscore.PmsApp;

import java.util.List;
import java.util.Scanner;

public class PmsConsoleApp {
    private PmsApp app;

    public PmsConsoleApp() {
        app = new PmsApp();
        this.run();
    }

    public void run() {
        this.app.initGuests();
        this.selectMainMenu();
    }

    private void clearScreen() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    private void selectMainMenu() {

        int selection;
        Scanner input = new Scanner(System.in);

        /***************************************************/
        this.clearScreen();
        System.out.println("PHAN MEM QUAN LY KHACH SAN");
        System.out.println("-------------------------\n");
        System.out.println("1. Quan ly ho so khach");
        System.out.println("2. Quan ly don dat phong");
        System.out.println("3. Quan ly checkin/checkout");
        System.out.println("0. Thoat");

        selection = input.nextInt();
        switch(selection){
            case 1:
                selectManageGuestMenu();
                break;
            case 2:
                //TO BE IMPLEMENTED
                break;
            case 3:
                //TO BE IMPLEMENTED
                break;
            case 0:
                break;
        }
    }

    private void selectManageGuestMenu() {

        int selection;
        Scanner input = new Scanner(System.in);

        /***************************************************/
        this.clearScreen();
        System.out.println("QUAN LY KHACH");
        System.out.println("-------------------------\n");

        this.showGuests(this.app.getGuests());

        /***************************************************/
        System.out.println("1. Tim kiem ho so khach");
        System.out.println("2. Them ho so khach");
        System.out.println("0. Thoat");

        selection = input.nextInt();
        switch(selection){
            case 1:
                this.searchGuests();
                break;
            case 2:
                //TO BE IMPLEMENTED
                break;
            case 3:
                //TO BE IMPLEMENTED
                break;
            case 0:
                this.selectMainMenu();
                break;
        }
    }

    private void showGuests(List<Guest> guests) {
        System.out.println("Ma\tTen");
        guests.stream().forEach(g -> {
            System.out.printf("%s\t%s\n", g.getGuestCode(), g.getGuestName());
        });
    }

    private void searchGuests(){
        String searchKey;
        Scanner input = new Scanner(System.in);

        /***************************************************/
        this.clearScreen();
        System.out.println("TIM KIEM KHACH");
        System.out.println("-------------------------\n");
        System.out.println("Nhap ten khach");

        searchKey = input.nextLine();
        List<Guest> guests = this.app.searchGuests(searchKey);
        if (guests.size() > 0) {
            this.showGuests(guests);
            input.nextLine();
            this.selectManageGuestMenu();
        } else {
            System.out.println("Khong co ket qua");
            System.out.println("-------------------------\n");
            System.out.println("1. Tim kiem lai");
            System.out.println("0. Quay lai");
            int selection = input.nextInt();
            switch(selection){
                case 1:
                    this.searchGuests();
                    break;
                case 0:
                    this.selectManageGuestMenu();
                    break;
            }
        }


    }
}
