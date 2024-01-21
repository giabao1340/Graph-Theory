using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Buoi03
{
    class AdjList
    {
        LinkedList<int>[] v;
        int n;  // Số đỉnh
        bool[] visited;     // Dùng đánh dấu đỉnh đã đi qua
        int[] index;        // Dùng đánh dấu các TPLT
        int inconnect;      // Dùng đếm số TPLT, và thêm propeties
        public int Inconnect { get => inconnect; set => inconnect = value; }
        //Propeties
        public int N { get => n; set => n = value; }
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
        public bool[] Visited { get => visited; set => visited = value; }   
        // Contructor
        public AdjList() { }
        public AdjList(int k)   // Khởi tạo v có k đỉnh
        {
            v = new LinkedList<int>[k];
        }
        // copy g --> đồ thị hiện tại v
        public AdjList(LinkedList<int>[] g)
        {
            v = g;
        }
        // Đọc file AdjList.txt --> danh sách kề v
        public void FileToAdjList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                string st = sr.ReadLine();
                // Đặt điều kiện không phải đỉnh cô lập
                if (st != "")
                {
                    string[] s = st.Split();
                    for (int j = 0; j < s.Length; j++)
                    {
                        int x = int.Parse(s[j]);
                        v[i].AddLast(x);
                    }
                }
            }
            sr.Close();
        }
        // Xuất đồ thị
        public void Output()
        {
            Console.WriteLine("Đồ thị danh sách kề - số đỉnh : " + n);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("   Đỉnh {0} ->", i);
                foreach (int x in v[i])
                    Console.Write("{0, 3}", x);
                Console.WriteLine();
            }
        }
        public void BFS(int s)
        {
            Queue<int> queue = new Queue<int>();
            visited = new bool[n];
            queue.Enqueue(s);
            visited[s] = true;
            while (queue.Count > 0)
            {
                s = queue.Dequeue();
                Console.Write(s +" ");
                foreach (int u in v[s])
                {
                    if (visited[u])
                    {
                        continue;
                    }
                    queue.Enqueue(u);
                    visited[u] = true;
                }
            }
        }
        public void BFS_XtoY(int x, int y)
        {
            int[] pre = new int[n];
            for (int i = 0; i < n; i++)
            {
                pre[i] = -1;
            }
            visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            visited[x] = true;
            queue.Enqueue(x);
            while (queue.Count > 0)
            {
                int s = queue.Dequeue();
                foreach (int u in v[s])
                {
                    if (visited[u])
                    {
                        continue;
                    }
                    visited[u] = true;
                    queue.Enqueue(u);
                    pre[u] = s;
                }
            }
            // Xuất đường đi từ x đến y
            Console.WriteLine();
            int k = y;
            Stack<int> stk = new Stack<int>();
            while (pre[k] != -1)
            {
                stk.Push(k);
                k = pre[k];
            }
            Console.WriteLine();
            Console.Write(" Đường đi từ " + x + " -> " + y + " :   " + x);
            while (stk.Count > 0)
            {
                k = stk.Pop();
                Console.Write(" -> " + k);
            }
            Console.WriteLine();
        }
        // Xét tính liên thông và xác định giá trị cho visite[], index[]
        // Xác định inconnect : số thành phần liên thông (TPLT)
        public void Connected()
        {
            // inconnect : số TPLT  giá trị ban đầu = 0  
            inconnect = 0;
            // index : lưu các đỉnh cùng một TPLT, khởi tạ index[] n phần tử
            index = new int[n];
            // Khởi gán index[i] = -1, Vi = 0 .. < n 
            visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                index[i] = -1;
            // Khởi tạo và giá trị ban đầu cho visited[i] = false, Vi = 0 .. < n
            }
            // Duyệt từng đỉnh i
            for (int i = 0; i < visited.Length; i++)
                // Nếu chưa duyệt đỉnh i (visited[i] == false)
                if (visited[i] == false)
                 {
                    // Khởi đầu cho một TPLT mới -> tăng inconnect++
                    inconnect++;
                // Tìm và đánh dấu các đỉnh cùng TPLT, gọi hàm
                BFS_Connected(i);
                 }
            Console.WriteLine();
        }
        // Lượt duyệt mới vớt đỉnh bắt đầu: s
        public void BFS_Connected(int s)
        {
            visited = new bool[n];
            // Sử dụng một queue cho giải thuật
            Queue<int> q = new Queue<int>();
            // Duyệt đỉnh s (visited[s] = true)
            visited[s] = true;
            // Đưa s vào q
            q.Enqueue(s);
            // Lặp khi queue q còn phần tử
            while(q.Count > 0)
            {
                // Lấy từ queue q ra một phần tử -> s
                s = q.Dequeue();
                // gán giá trị TPLT : index[s] = inconnect;
                index[s] = inconnect;
                // Duyệt các đỉnh kề u của s (int u in v[s])
                foreach (int u in v[s])
                {
                    // Nếu u chưa duyệt (visited[u] == false)
                    if (!visited[u])
                    {
                        // Duyệt u : visited[u] = true;
                        visited[u] = true;
                        // Đưa u vào Queue q
                        q.Enqueue(u);
                    }
                }
            }
        }
        // Xuất các thành phần liên thông
        public void OutConnected()
        {
            for (int i = 1; i <= inconnect; i++)
            {
                Console.Write("  TPLT {0} : ", i);
                for (int j = 0; j < index.Length; j++)
                    if (index[j] == i)
                        Console.Write(j + " ");
                Console.WriteLine();
            }
        }

    }
}