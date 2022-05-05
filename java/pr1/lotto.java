/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projektnazaliczenie;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author arek
 */
public class lotto {

    private int liczbawylosowana;
    private int liczbawytypowana;
    private double kumulacja;

    public void losowanie() throws FileNotFoundException, IOException {
        int a;
        Random rand = new Random();
        a = rand.nextInt(9000);
        a = a + 1000;
        setLiczbawylosowana(a);
        DataOutputStream los;
        los = new DataOutputStream(new FileOutputStream("los.bin"));
        los.writeInt(getLiczbawylosowana());
        los.close();
        System.out.println("blokada zwolniona kulki wpadły do bębna maszyny losującej liczba została wylosowana");
        DataOutputStream kum;
        kum = new DataOutputStream(new FileOutputStream("kumulacja.bin"));
        kum.writeDouble(0.0);
        kum.close();
        DataOutputStream kasacja;
        kasacja = new DataOutputStream(new FileOutputStream("typ.bin"));
        kasacja.close();
    }

    public void losowanieUstawione() throws FileNotFoundException, IOException {
        int a;
        a = 1111;
        setLiczbawylosowana(a);
        DataOutputStream los;
        los = new DataOutputStream(new FileOutputStream("los.bin"));
        los.writeInt(getLiczbawylosowana());
        los.close();
        System.out.println("blokada zwolniona kulki wpadły do bębna maszyny losującej liczba została ustawiona");
        DataOutputStream kum;
        kum = new DataOutputStream(new FileOutputStream("kumulacja.bin"));
        kum.writeDouble(0.0);
        kum.close();
        DataOutputStream kasacja;
        kasacja = new DataOutputStream(new FileOutputStream("typ.bin"));
        kasacja.close();
    }

    public void typowanie() throws FileNotFoundException, IOException {
        int t;
        double pln, kumOdczytane;
        Scanner odczyt = new Scanner(System.in);
        do {
            System.out.println("Proszę wytypować liczbę 4 cyfrową cena 5 pln");
            t = odczyt.nextInt();
        } while (t > 10000 || t < 1000);
        setLiczbawytypowana(t);
        DataInputStream odczytKum = null;
        odczytKum = new DataInputStream(new FileInputStream("kumulacja.bin"));
        kumOdczytane = odczytKum.readDouble();
        pln = kumOdczytane;
        pln = pln + 5.0;
        setKumulacja(pln);
        DataOutputStream typ;
        typ = new DataOutputStream(new FileOutputStream("typ.bin", true));
        typ.writeInt(getLiczbawytypowana());
        typ.close();
        DataOutputStream kum;
        kum = new DataOutputStream(new FileOutputStream("kumulacja.bin"));
        kum.writeDouble(getKumulacja());
        kum.close();
    }

    public void konieclosowania() throws FileNotFoundException, IOException {
        int los, typ = 0, dlugosc;
        double licznikTrafien = 0, kum, wygrana;
        DataInputStream odczytLos = null;
        odczytLos = new DataInputStream(new FileInputStream("los.bin"));
        los = odczytLos.readInt();
        setLiczbawylosowana(los);
        System.out.println("Wynik losowania to " + getLiczbawylosowana());
        DataInputStream odczytTyp = null;
        odczytTyp = new DataInputStream(new FileInputStream("typ.bin"));
        DataInputStream odczytKum = null;
        odczytKum = new DataInputStream(new FileInputStream("kumulacja.bin"));
        kum = odczytKum.readDouble();
        while (true) {
            try {
                typ = odczytTyp.readInt();
            } catch (EOFException ex1) {
                break;
            }
            if (typ == los) {
                licznikTrafien = licznikTrafien + 1.0;
            }
        }
        System.out.println((int) licznikTrafien + " trafień");
        wygrana = kum / licznikTrafien;
        if (licznikTrafien != 0.0) {

            System.out.println("Wygrana wynosi " + wygrana + " pln");
        }
        DataOutputStream kasacja;
        kasacja = new DataOutputStream(new FileOutputStream("typ.bin"));
        kasacja.close();
        setKumulacja(0.0);

    }

    public int getLiczbawylosowana() {
        return liczbawylosowana;
    }

    public int getLiczbawytypowana() {
        return liczbawytypowana;
    }

    public double getKumulacja() {
        return kumulacja;
    }

    public void setLiczbawylosowana(int liczbawylosowana) {
        this.liczbawylosowana = liczbawylosowana;
    }

    public void setLiczbawytypowana(int liczbawytypowana) {
        this.liczbawytypowana = liczbawytypowana;
    }

    public void setKumulacja(double kumulacja) {
        this.kumulacja = kumulacja;
    }

}
