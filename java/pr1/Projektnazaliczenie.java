/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projektnazaliczenie;

import java.io.IOException;
import java.util.Scanner;

public class Projektnazaliczenie {

    public static void main(String[] args) throws IOException {
        lotto a = new lotto();
        int w = 0;
        Scanner scan = new Scanner(System.in);
        do {
            System.out.println("\nWybierz 1 aby wylosować liczbę wybierz 2 aby wytypować liczbę wybierz 3 aby zakończyć losowanie wybierz 4 aby ustawić losowanie 10 aby zakończyć program");
            System.out.println("kumulacja wynosi "+a.getKumulacja()+"pln");
            w = scan.nextInt();
            switch (w) {
                case 1:
                    a.losowanie();
                    break;
                case 2:
                    a.typowanie();
                    break;
                case 3:
                    a.konieclosowania();
                    break;
                case 4:
                    a.losowanieUstawione();
                    break;
            }
        } while (w != 10);
    }

}
