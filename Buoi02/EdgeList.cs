using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Buoi02
{
    class EdgeList
    {
        LinkedList<Tuple<int, int>> g;
        int n;      // số đỉnh
        int m;      // số cạnh
        // Propeties
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public LinkedList<Tuple<int, int>> G { get => g; set => g = value; }
        // constructor
        public EdgeList()
        {
            g = new LinkedList<Tuple<int, int>>();
        }
        // Đọc file EdgeList.txt --> g
        public void FileToEdgeList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split();
                // khởi tạo một cạnh mới
                Tuple<int, int> e = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]));
                g.AddLast(e);
            }
            sr.Close();
        }
        // Xuất danh sách cạnh lên màn hình
        public void Output()
        {
            Console.WriteLine("Danh sách cạnh của đồ thị với số đỉnh n = " + n);
            foreach (Tuple<int, int> e in g)
                Console.WriteLine("      (" + e.Item1 + "," + e.Item2 + ")");
        }
        // Tính bậc các đỉnh
        public int FindDegV(int i)
        {
            int count = 0;
            foreach (Tuple<int, int> e in g)
                if (i == e.Item1 || i == e.Item2)
                {
                    //Console.WriteLine(e.Item1 +" " + e.Item2);
                    count++;
                }
            return count;
        }
        public void DegV()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Bậc của đỉnh {i}: {FindDegV(i)}");
            }
        }
        static AdjList EdgeListToAdjList(EdgeList ge)
        {
            // Khởi tạo đồ thị AdjList
            AdjList ga = new AdjList();
            // Xác định số đỉnh n của đồ thị : ga.N = ge.N;
            ga.N = ge.N;
            // Khởi tạo array v[] của đồ thị AdjList
            // Khởi tạo các danh sách liên kết ga.V[i]
            // Duyệt từng đỉnh i trong ga , i = 0..ga.N-1
            // Khởi tạo các dslk : ga.V[i] = new LinkedList<int>();
            // Xây dựng các phấn tử cho các dslk
            // Duyệt từng cạnh e trong đồ thị EdgeList
            {
                // AddLast e.Item2 vào ga.V[e.Item1]
                // AddLast e.Item1 vào ga.V[e.Item2]
            }
            return ga;	// Đồ thị trả về
        }
    }
}