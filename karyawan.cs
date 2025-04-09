using System;

// Induk Class
public class Karyawan
{
    // Atribut
    private string nama;
    private string id;
    private double gajiPokok;

    // Constructor
    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    // Getter Setter
    public string GetNama()
    {
        return nama;
    }

    public void SetNama(string nama)
    {
        this.nama = nama;
    }

    public string GetId()
    {
        return id;
    }

    public void SetId(string id)
    {
        this.id = id;
    }

    public double GetGajiPokok()
    {
        return gajiPokok;
    }

    public void SetGajiPokok(double gajiPokok)
    {
        this.gajiPokok = gajiPokok;
    }

    // Override oleh kelas turunan
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

// Bagian Kelas turunan
public class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    // Override metode HitungGaji
    public override double HitungGaji()
    {
        return GetGajiPokok() + BonusTetap;
    }
}

public class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    // Override metode HitungGaji
    public override double HitungGaji()
    {
        return GetGajiPokok() - PotonganKontrak;
    }
}

public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    // Override metode HitungGaji
    public override double HitungGaji()
    {
        return GetGajiPokok(); // Tidak ada bonus atau potongan
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEM MANAJEMEN KARYAWAN ===");

        // Input jenis karyawan
        Console.WriteLine("\nPilih jenis karyawan:");
        Console.WriteLine("1. Karyawan Tetap");
        Console.WriteLine("2. Karyawan Kontrak");
        Console.WriteLine("3. Karyawan Magang");
        Console.Write("Masukkan pilihan (1-3): ");
        int pilihan = Convert.ToInt32(Console.ReadLine());

        // Input data karyawan
        Console.Write("\nMasukkan nama karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID karyawan: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan gaji pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        // Membuat objek sesuai jenis karyawan
        Karyawan karyawan = null;

        switch (pilihan)
        {
            case 1:
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                Console.WriteLine("\nJenis Karyawan: Karyawan Tetap");
                break;
            case 2:
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                Console.WriteLine("\nJenis Karyawan: Karyawan Kontrak");
                break;
            case 3:
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                Console.WriteLine("\nJenis Karyawan: Karyawan Magang");
                break;
            default:
                Console.WriteLine("Tidak ada pilihan / tidak valid!!");
                return;
        }

        // Menampilkan informasi karyawan
        Console.WriteLine("Nama: " + karyawan.GetNama());
        Console.WriteLine("ID: " + karyawan.GetId());
        Console.WriteLine("Gaji Pokok: " + karyawan.GetGajiPokok());
        Console.WriteLine("Gaji Akhir: " + karyawan.HitungGaji());
    }
}
