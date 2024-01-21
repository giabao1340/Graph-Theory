﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;   // Thư viện cho đối tượng LinkedList

namespace Buoi02
{
    class AdjList
    {
        LinkedList<int>[] v;
        int n;  // Số đỉnh
        //Propeties
        public int N { get => n; set => n = value; }
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
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
        public void AdjListToFile(string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                foreach (int x in v[i])
                {
                    sw.Write(x+" ");
                }
                sw.WriteLine();
            }
            sw.Close();
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
        // Phương thức tính bậc của các đỉnh, ghi file và xuất lên màn hình
        public void DegV()
        {
            // Duyệt các đỉnh (các phần tử v[i])
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i} : {v[i].Count}");
            }
            // 	Bậc của đỉnh i = số phần tử của dslk v[i]
            // 	Ghi file và xuất lên màn hình theo yêu cầu
            // Đóng file
        }

    }
}