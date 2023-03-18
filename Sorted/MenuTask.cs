using System;

namespace Sorted
{
    class MenuTask
    {
        private static int n = 0;
        private static int[] arr;

        public void Run()
        {
            int number = 0;

            do
            {
                DisplayMenu();
                number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        n = int.Parse(Console.ReadLine());
                        CreateArray(ref arr, n);
                        break;
                    case 2:
                        Print(arr);
                        break;
                    case 3:
                        SortChoice(ref arr);
                        break;
                    case 4:
                        HeapSort(ref arr);
                        break;
                    case 5:
                        BubbleSort(ref arr);
                        break;
                    case 6:
                        ShakerSort(ref arr);
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }

            } while (number != 7);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1 - Создать массив");
            Console.WriteLine("2 - Вывести элементы массива");
            Console.WriteLine("3 - Сортировка выбором");
            Console.WriteLine("4 - Пирамидальная сортировка");
            Console.WriteLine("5 - Сортировка «Пузырькам»");
            Console.WriteLine("6 - Шейкер сортировка");
            Console.WriteLine("7 - Выход");
            Console.WriteLine("Введите номер от 1 до 7:");
        }

        private static void CreateArray(ref int[] arr, int n)
        {
            arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите {i + 1}-й элемент: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Массив создан.");
        }

        private static void Print(int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }

            Console.Write("Элементы массива: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        private static void SortChoice(ref int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            Console.WriteLine("Массив отсортирован методом сортировки выбором.");
        }

        private static void HeapSort(ref int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }

            for (int i = arr.Length / 2 - 1; i >= 0; i = i - 1)
            {
                Heapify(ref arr, i, arr.Length);
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(ref arr, 0, i);
            }

            Console.WriteLine("Массив отсортирован методом пирамидальной сортировки.");
        }

        private static void Heapify(ref int[] arr, int rootIndex, int size)
        {
            int largest = rootIndex;
            int leftIndex = 2 * rootIndex + 1;
            int rightIndex = 2 * rootIndex + 2;

            if (leftIndex < size && arr[leftIndex] > arr[largest])
            {
                largest = leftIndex;
            }

            if (rightIndex < size && arr[rightIndex] > arr[largest])
            {
                largest = rightIndex;
            }

            if (largest != rootIndex)
            {
                int temp = arr[rootIndex];
                arr[rootIndex] = arr[largest];
                arr[largest] = temp;

                Heapify(ref arr, largest, size);
            }
        }

        private static void BubbleSort(ref int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Массив отсортирован методом сортировки «Пузырьком».");
        }

        private static void ShakerSort(ref int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }

            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                    }
                }
                left++;
            }

            Console.WriteLine("Массив отсортирован методом шейкерной сортировки.");
        }
    }
}