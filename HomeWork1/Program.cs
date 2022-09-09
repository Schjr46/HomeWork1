using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mang_1_chieu
{
    class Program
    {
        static void inPut(float[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[" + i + "]=");
                a[i] = float.Parse(Console.ReadLine());
            }
        }
        static void outPut(float[] a, int n)
        {
            Console.Write("Hien thi mang:");
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
        }

        static void swap(ref float x,ref float y)
        {
            float t = x;
            x = y;
            y = t;
        }

        static int partition(float []a, int low, int high)
        {
            float pivot = a[high];    // pivot
            int left = low;
            int right = high - 1;
            while (true)
            {
                while (left <= right && a[left] < pivot) left++;    //tim pt be hon pivot
                while (right >= left && a[right] > pivot) right--;  //tim pt lon hon pivot
                if (left >= right) break;
                swap(ref a[left], ref a[right]);
                left++;
                right--;
            }
            swap(ref a[left],ref a[high]);
            return left;
        }

     static void quickSort(float []a, int low, int high)
        {
            if (low < high)
            {
              
                int pi = partition(a, low, high);


                quickSort(a, low, pi - 1);
                quickSort(a, pi + 1, high);
            }
        }
        // 0 < 5 && 9 < 4
        // 4>0 && 6 >4
        // 
        // 
        // 
        static  int binarySearch(float[] a, int l,
                            int r,float x)
        {
            if (r < l)
                return -1;

            int mid = l + (r - l) / 2;

            if (a[mid] == x)
                return mid;

            if (a[mid] > x)
                return binarySearch(a, l, mid - 1, x);

            return binarySearch(a, mid + 1, r, x);
        }
        static float countOccurrences(float[] a,
                                int n, float x)
        {
            int ind = binarySearch(a, 0,
                                   n - 1, x);

            // tra ve 0 neu ko tim thay index
            if (ind == -1)
                return 0;

            // dem cac pt ben trai index
            int count = 1;
            int left = ind - 1;
            while (left >= 0 &&
                   a[left] == x)
            {
                count++;
                left--;
            }

            // dem ac pt ben phai index
            int right = ind + 1;
            while (right < n &&
                   a[right] == x)
            {
                count++;
                right++;
            }

            return count;
        }
        static void Main(string[] args)
        {
            float[] a = { 9, 4.3f, 4, 5, 6.3f, 4, 2.2f ,7.7f, 7.7f };
            int n = a.Length;
           // Console.Write("Nhap so ptu cua mang: ");
            //int n = int.Parse(Console.ReadLine());
           // float[] a = new float[100];
           // inPut(a, n);
            outPut(a, n);
            quickSort(a, 0, n - 1);
            Console.Write("\nSorted array: \n");
            outPut(a, n);

            
            Console.WriteLine("\n");

            //float i = 2.2f;
                foreach(float i in a.Distinct())
                 
                    {
                        Console.Write("\n" + i + " xuat hien " +countOccurrences(a, n, i) + " lan " );
                    }

            Console.ReadKey();
        }
    }
}