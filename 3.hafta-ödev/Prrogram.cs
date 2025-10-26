using System;
using System.Collections.Generic;

public class Node
{
    public int Veri;
    public Node sonraki;
    public Node onceki;

    public Node(int veri)
    {
        Veri = veri;
        sonraki = null;
        onceki = null;
    }
}

public class CiftYonluListe
{
    private Node bas;
    private Node son;

    public CiftYonluListe()
    {
        bas = null;
        son = null;
    }

    // 1. BAŞA EKLEME
    public void BasaEkle(int veri)
    {
        Node yeniNode = new Node(veri);
        
        if (bas == null)
        {
            bas = yeniNode;
            son = yeniNode;
        }
        else
        {
            yeniNode.sonraki = bas;
            bas.onceki = yeniNode;
            bas = yeniNode;
        }
        Console.WriteLine(veri + " başa eklendi.");
    }

    // 2. SONA EKLEME
    public void SonaEkle(int veri)
    {
        Node yeniNode = new Node(veri);
        
        if (son == null)
        {
            bas = yeniNode;
            son = yeniNode;
        }
        else
        {
            son.sonraki = yeniNode;
            yeniNode.onceki = son;
            son = yeniNode;
        }
        Console.WriteLine(veri + " sona eklendi.");
    }

    // 3. ARAYA HERHANGİ BİR VERİDEN SONRA EKLEME
    public void ArayaSonraEkle(int aramaVeri, int yeniVeri)
    {
        Node current = bas;
        
        while (current != null)
        {
            if (current.Veri == aramaVeri)
            {
                Node yeniNode = new Node(yeniVeri);
                
                yeniNode.sonraki = current.sonraki;
                yeniNode.onceki = current;
                
                if (current.sonraki != null)
                    current.sonraki.onceki = yeniNode;
                else
                    son = yeniNode;
                    
                current.sonraki = yeniNode;
                Console.WriteLine(yeniVeri + " değeri " + aramaVeri + " değerinden sonra eklendi.");
                return;
            }
            current = current.sonraki;
        }
        Console.WriteLine(aramaVeri + " değeri bulunamadı.");
    }

    // 4. ARAYA HERHANGİ BİR VERİDEN ÖNCE EKLEME
    public void ArayaOnceEkle(int aramaVeri, int yeniVeri)
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        if (bas.Veri == aramaVeri)
        {
            BasaEkle(yeniVeri);
            return;
        }

        Node current = bas;
        
        while (current != null)
        {
            if (current.Veri == aramaVeri)
            {
                Node yeniNode = new Node(yeniVeri);
                
                yeniNode.sonraki = current;
                yeniNode.onceki = current.onceki;
                current.onceki.sonraki = yeniNode;
                current.onceki = yeniNode;
                
                Console.WriteLine(yeniVeri + " değeri " + aramaVeri + " değerinden önce eklendi.");
                return;
            }
            current = current.sonraki;
        }
        Console.WriteLine(aramaVeri + " değeri bulunamadı.");
    }

    // 5. BAŞTAN SİLME
    public void BastanSil()
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        int silinenVeri = bas.Veri;
        
        if (bas == son)
        {
            bas = null;
            son = null;
        }
        else
        {
            bas = bas.sonraki;
            bas.onceki = null;
        }
        Console.WriteLine(silinenVeri + " baştan silindi.");
    }

    // 6. SONDAN SİLME
    public void SondanSil()
    {
        if (son == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        int silinenVeri = son.Veri;
        
        if (bas == son)
        {
            bas = null;
            son = null;
        }
        else
        {
            son = son.onceki;
            son.sonraki = null;
        }
        Console.WriteLine(silinenVeri + " sondan silindi.");
    }

    // 7. ARADAN ARAYARAK SİLME
    public void AradanSil(int veri)
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Node current = bas;
        
        while (current != null)
        {
            if (current.Veri == veri)
            {
                if (current == bas)
                {
                    BastanSil();
                }
                else if (current == son)
                {
                    SondanSil();
                }
                else
                {
                    current.onceki.sonraki = current.sonraki;
                    current.sonraki.onceki = current.onceki;
                    Console.WriteLine(veri + " değeri listeden silindi.");
                }
                return;
            }
            current = current.sonraki;
        }
        Console.WriteLine(veri + " değeri bulunamadı.");
    }

    // 8. ARAMA
    public void Ara(int veri)
    {
        Node current = bas;
        int pozisyon = 1;
        
        while (current != null)
        {
            if (current.Veri == veri)
            {
                Console.WriteLine(veri + " değeri " + pozisyon + ". pozisyonda bulundu.");
                return;
            }
            current = current.sonraki;
            pozisyon++;
        }
        Console.WriteLine(veri + " değeri bulunamadı.");
    }

    // 9. LİSTELEME
    public void Listele()
    {
        if (bas == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Node current = bas;
        Console.Write("Liste: ");
        
        while (current != null)
        {
            Console.Write(current.Veri);
            if (current.sonraki != null)
                Console.Write(" -> ");
            current = current.sonraki;
        }
        Console.WriteLine();
    }

    // 10. TÜMÜNÜ SİLME
    public void TumunuSil()
    {
        bas = null;
        son = null;
        Console.WriteLine("Tüm liste temizlendi.");
    }

    // 11. TÜM LİNKED LİST'İ BİR DİZİYE ATMA
    public int[] DiziyeCevir()
    {
        List<int> veriListesi = new List<int>();
        Node current = bas;
        
        while (current != null)
        {
            veriListesi.Add(current.Veri);
            current = current.sonraki;
        }
        
        return veriListesi.ToArray();
    }

    // Diziyi görüntüleme metodu
    public void DiziyiGoster(int[] dizi)
    {
        if (dizi.Length == 0)
        {
            Console.WriteLine("Dizi boş.");
            return;
        }

        Console.Write("Dizi: ");
        foreach (var veri in dizi)
        {
            Console.Write(veri + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        CiftYonluListe liste = new CiftYonluListe();
        
        // Tüm işlemlerin test edilmesi:
        
        // 1. Başa ekleme
        liste.BasaEkle(30);
        liste.BasaEkle(20);
        liste.BasaEkle(10);
        
        // 2. Sona ekleme
        liste.SonaEkle(40);
        liste.SonaEkle(50);
        
        liste.Listele();
        
        // 3. Araya sonra ekleme
        liste.ArayaSonraEkle(20, 25);
        
        // 4. Araya önce ekleme
        liste.ArayaOnceEkle(40, 35);
        
        liste.Listele();
        
        // 5. Baştan silme
        liste.BastanSil();
        
        // 6. Sondan silme
        liste.SondanSil();
        
        liste.Listele();
        
        // 7. Aradan arayarak silme
        liste.AradanSil(25);
        
        // 8. Arama
        liste.Ara(35);
        
        liste.Listele();
        
        // 9. Listeleme (zaten yukarıda kullanıldı)
        
        // 10. Tümünü silme
        liste.TumunuSil();
        
        liste.Listele();
        
        // Tekrar veri ekleyip diziye çevirme testi
        liste.BasaEkle(100);
        liste.SonaEkle(200);
        liste.BasaEkle(50);
        
        liste.Listele();
        
        // 11. Tüm linked list'i bir diziye atma
        int[] dizi = liste.DiziyeCevir();
        liste.DiziyiGoster(dizi);
    }
}