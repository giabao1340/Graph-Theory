using System;
using System.IO;
using System.Text;
namespace Buoi01
{
    class AdjMatrix
    {
        public int n;   // số đỉmh
        public int[,] a;    // Ma trận kề
        // propeties
        public int N { get => n; set => n = value; }
        public int[,] A { get => a; set => a = value; }
        // constructor không đối số
        public AdjMatrix() { }
        // constructor có đối số k là số đỉnh của đồ thị
        public AdjMatrix(int k)
        {
            n = k;
            a = new int[n, n];
        }
        // Đọc file AdjMatrix --> ma trận a
        public void FileToAdjMatrix(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    a[i, j] = int.Parse(s[j]);
            }
            sr.Close();
        }
        // Xuất ma trận a lên màn hình
        public void Output()
        {
            Console.WriteLine("Đồ thị ma trận kề - số đỉnh : " + n);
            Console.WriteLine();
            Console.Write(" Đỉnh |");
            for (int i = 0; i < n; i++) Console.Write("    {0}", i);
            Console.WriteLine(); Console.WriteLine("  " + new string('-', 6 * n));
            for (int i = 0; i < n; i++)
            {
                Console.Write("    {0} |", i);
                for (int j = 0; j < n; j++)
                    Console.Write("  {0, 3}", a[i, j]);
                Console.WriteLine();
            }
        }
        // Các phương thức xử lý các thao tác trên đồ thị là bài tập thực hành
        // Tính bậc của đỉnh i
        public int DegVi(int i)
        {
            int count = 0;

            // Duyệt từng cột j trên dòng i
            for (int j = 0; j < n; j++)
            {
                // Đếm số lượng ô(i, j) = 1
                if (a[i, j] != 0)
                {
                    count++;
                }
            }
            // Trả về kết quả
            return count;

        }
        // Bậc của các đỉnh, tham số là tên file để ghi kết quả
        public void DegVs()
        {
            // Sử dụng đối tượng : StreamWriter sw = new StreamWriter(filePath);
            // Duyệt từng đỉnh của đồ thị
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Bậc của đỉnh {i}: {DegVi(i)}");
            }
            //      Tính bậc của đỉnh i : DegVi(i);
            //      Ghi vào file filePath và xuất lên màn hình theo yêu cầu
            // Đóng file
        }
        //Bai 2
        // 1. Tính bậc ra của đỉnh i
        public int DegOut(int i)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (a[i, j] != 0)
                {
                    count++;
                }
            }
            return count;
        }
        // 2. Tính bậc vào của đỉnh j
        public int DegIn(int j)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i, j]  != 0)
                {
                    count++;
                }
            }
            return count;
        }
        // 3. Xuất bậc vào bậc ra của các đỉnh theo yêu cầu
        public void DegInOut()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i}: {DegIn(i)} - {DegOut(i)}");
            }
        }
        // Xác định đỉnh i là đỉnh bồn chứa hay không ?
        public bool IsStorage(int i)
        {
            // Duyệt các cột j của ma trận a, j = 0..n-1
            for (int j = 0; j < n; j++)
            {
                // Nếu tồn tại a[i, j] = 1 thì i không phải đỉnh bồn chứa ( return false)
                if (a[i, j] == 1)
                {
                    return false;
                }

            }
            // Kết thúc vòng lặp : return true (i là đỉnh bồn chứa)
            return true;
        }

    }
}
