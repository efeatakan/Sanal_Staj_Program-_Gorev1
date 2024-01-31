using System;
using System.Collections.Generic;

struct List
{
    public string Title; 
    public string Author; 
    public int Copies; 
    public DateTime DueDate; 
} 

class Program
{
        
    
    static List[] library = new List[50];
    
    static int count=0;
    static int i=0;
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Kutuphaneye yeni bir kitap ekle");
            Console.WriteLine("2. Kutuphanedeki tum kitaplarin listesini goruntule");
            Console.WriteLine("3. Bir kitabi basligina veya yazarina gore ara");
            Console.WriteLine("4. Bir kitap odunc al");
            Console.WriteLine("5. Bir kitabi iade et");
            Console.WriteLine("6. Suresi gecmis kitaplarla ilgili bilgileri goruntule");
            Console.WriteLine("0. Cikis");

            Console.Write("Islem seciniz: ");
            int choice = int.Parse(Console.ReadLine());

        while(true){
                if(choice==1){
                    Kitap_ekle();
                    break;}
                else if(choice==2){
                    Kitap_listesi();
                    break;}
                else if(choice==3){
                    Kitap_arama();
                    break;}
                else if(choice==4){
                    Kitap_odunc_alma();
                    break;}
                else if(choice==5){
                    Kitap_iade_et();
                    break;}
                else if(choice==6){
                    Suresi_gecmis_kitaplar();
                    break;}
                else if(choice==0){
                    Environment.Exit(0);
                    break;}
                else
                    Console.WriteLine("Tekrar deneyiniz ");
                    
        }    

            Console.WriteLine("\n\n");
        }
    }

    static void Kitap_ekle()
    {
        Console.Write("Kitabin adi: ");
        library[i].Title = Console.ReadLine().ToLower();

        Console.Write("Yazari: ");
        library[i].Author = Console.ReadLine().ToLower();
        
        Console.Write("Kac gun sureyle odunc alinabilir: ");
        int dueDays = int.Parse(Console.ReadLine());
        library[i].DueDate = DateTime.Now.AddDays(dueDays);

        int j=0;
        for (j = 0; j < count; j++)
			{
			 if(library[i].Title ==  library[j].Title)
			 {   
			     i=j;
			 }
			}
		library[i].Copies++;
        count++;

        Console.WriteLine("Kitap eklendi!");
    }

    static void Kitap_listesi()
    {
        if(count != 0){
        Console.WriteLine("Tüm kitaplar:");

        for (i = 0; i < count; i++)
			{
				Console.WriteLine($"Book name = {library[i].Title}, Author name = {library[i].Author}, Kopya Sayısı: {library[i].Copies}");
			}
        }
        else
        {
            Console.WriteLine("Kayitli kitap yok ");
        }
    }
    

    static void Kitap_arama()
    {
        Console.Write("Kitap adi veya yazar ismi giriniz: ");
		string searchTerm = Console.ReadLine().ToLower();
		for (i = 0; i < count; i++)
			{
				if (searchTerm == library[i].Author)
					Console.WriteLine($"Adi: {library[i].Title}, Yazari: {library[i].Author}, Kopya sayisi: {library[i].Copies}");
				else if(searchTerm == library[i].Title)
				    Console.WriteLine($"Adi: {library[i].Title}, Yazari: {library[i].Author}, Kopya sayisi: {library[i].Copies}");
			}
    }

    static void Kitap_odunc_alma()
{
    Console.Write("Odunc alınacak kitabin adi: ");
    string title = Console.ReadLine().ToLower();

    int sira = -1;
    for (i = 0; i < count; i++)
    {
        if (title == library[i].Title.ToLower())
        {
            sira = i;
            break;
        }
    }

    if (sira != -1 && library[sira].Copies > 0)
    {
        library[sira].Copies--;
        Console.WriteLine($"'{library[sira].Title}' adli kitap odunc alindi. Kalan kopya sayisi: {library[sira].Copies}");
    }
    else if (sira != -1)
    {
        Console.WriteLine("Seçilen kitap ödünç alınamaz. Kopya mevcut değil.");
    }
    else
    {
        Console.WriteLine("Kitap bulunamadı.");
    }
}



    static void Kitap_iade_et()
{
    Console.Write("Iade edilecek kitabin adi: ");
    string title = Console.ReadLine().ToLower();

    int sira = -1;
    for (i = 0; i < count; i++)
    {
        if (title == library[i].Title.ToLower())
        {
            sira = i;
            break;
        }
    }

    if (sira != -1)
    {
        library[sira].Copies++;
        Console.WriteLine($"'{library[sira].Title}' adli kitap iade edildi. Kalan kopya sayısı: {library[sira].Copies}");
    }
    else
    {
        Console.WriteLine("Kitap bulunamadı.");
    }
}
    
    static void Suresi_gecmis_kitaplar()
{
    Console.WriteLine("Suresi gecmis kitaplar:");

    for (int j = 0; j < count; j++)
    {
        if (library[j].DueDate < DateTime.Now)
        {
            Console.WriteLine($"Adi: {library[j].Title}, Yazari: {library[j].Author}, Kopya sayisi: {library[j].Copies}, Son iade tarihi: {library[j].DueDate}");
        }
    }
}


}