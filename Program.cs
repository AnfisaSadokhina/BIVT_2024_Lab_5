using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (k == 0 || k > 0 && k == n) answer = 1;
        else if (k > 0 && k < n) answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        // create and use Combinations(n, k);
        // create and use Factorial(n);
        long Factorial(int n)
        {
            long f = 1;
            for (int i = 2; i <= n; i++) f *= i;
            return f;
        }
        // end
        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a = first[0], b = first[1], c = first[2];
        double d = second[0], e = second[1], f = second[2];
        if (a >= (b + c)) return -1;
        if (b >= (a + c)) return -1;
        if (c >= (a + b)) return -1;
        if (d >= (e + f)) return -1;
        if (e >= (d + f)) return -1;
        if (f >= (d + e)) return -1;

        double F = GeronArea(a, b, c);
        double S = GeronArea(d, e, f);
        if (F > S) return 1;
        if (F < S) return 2;
        if (F == S) return 0;
        // create and use GeronArea(a, b, c);
        // end
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        // code here
        // create and use GetDistance(v, a, t); t - hours
        double dis1 = GetDistance(v1, a1, time);
        double dis2 = GetDistance(v2, a2, time);

        if (dis1 > dis2) answer = 1;
        if (dis2 > dis1) answer = 2;
        if (dis2 == dis1) answer = 0;
        // end
        // first = 1, second = 2, equal = 0
        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        double s = v * t + a * t * t / 2; return s;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        // code here
        int t = 1;
        while (GetDistance(v1, a1, t) > GetDistance(v2, a2, t)) t++;
        answer = t;
        // use GetDistance(v, a, t); t - hours
        // end
        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxIndex(matrix, out row, out column);
        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            row = 0; column = 0;
            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max) { max = matrix[i, k]; row = i; column = k; }
                }
            }
        }
        int rowA = 0, columnA = 0, rowB = 0, columnB = 0;
        FindMaxIndex(A, out rowA, out columnA); FindMaxIndex(B, out rowB, out columnB);
        int temp = A[rowA, columnA];
        A[rowA, columnA] = B[rowB, columnB];
        B[rowB, columnB] = temp;
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        if ((B.GetLength(0) == 5) && (C.GetLength(0) == 6) && (C.GetLength(1) == 6) && (B.GetLength(1) == 5))
        {
            int[,] b = new int[B.GetLength(0) - 1, B.GetLength(1)];
            int[,] c = new int[C.GetLength(0) - 1, C.GetLength(1)];

            static int FindDiagonalMax(int[,] A)
            {
                int max = -1000, n = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    if (A[i, i] > max) { max = A[i, i]; n = i; }
                }
                return n;
            }

            static int[,] X(int[,] A, int a)
            {
                int[,] B = new int[A.GetLength(0) - 1, A.GetLength(1)];
                for (int i = 0; i < a; i++)
                {
                    for (int k = 0; k < A.GetLength(1); k++) B[i, k] = A[i, k];
                }
                for (int h = a; h < A.GetLength(0) - 1; h++)
                {
                    for (int f = 0; f < A.GetLength(1); f++) B[h, f] = A[h + 1, f];
                }
                return B;
            }
            b = X(B, FindDiagonalMax(B));
            B = b;
            c = X(C, FindDiagonalMax(C));
            C = c;


        }
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        static void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || columnIndex < 0 || columnIndex >= matrix.GetLength(1)) { rowIndex = -1; return;}
            rowIndex = 0;
            int max = matrix[0, columnIndex];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columnIndex] > max) { max = matrix[i, columnIndex]; rowIndex = i; }
            }
        }
        int rA, rB;
        FindMaxInColumn(A, 0, out rA); FindMaxInColumn(B, 0, out rB);
        if (rA != -1 && rB != -1)
        {
            int[] rowA = new int[A.GetLength(1)]; int[] rowB = new int[B.GetLength(1)];
            for (int i = 0; i < A.GetLength(1); i++) rowA[i] = A[rA, i];
            for (int k = 0; k < B.GetLength(1); k++) rowB[k] = B[rB, k];
            for (int h = 0; h < A.GetLength(1); h++) A[rA, h] = rowB[h];
            for (int j = 0; j < B.GetLength(1); j++) B[rB, j] = rowA[j];
        }
        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        // create and use CountRowPositive(matrix, rowIndex);
        static int CountRowPositive(int[,] matrix, int rowIndex)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return -1;
            int s = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[rowIndex, i] > 0) s++;
            }
            return s;
        }
        // create and use CountColumnPositive(matrix, colIndex);
        static int CountColumnPositive(int[,] matrix, int colIndex)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return -1;
            int s = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > 0) s++;
            }
            return s;
        }
        int maxi1 = -1, maxi2 = -1;
        int maxk1 = -1, maxk2 = -1;
        if (B != null && B.GetLength(0) != 0)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                int k = CountRowPositive(B, i);
                if (k > maxi2) { maxi2 = k; maxi1 = i; }
            }
        }
        if (C != null && C.GetLength(0) != 0)
        {
            for (int i = 0; i < C.GetLength(1); i++)
            {
                int k = CountColumnPositive(C, i);
                if (k > maxk2) { maxk2 = k; maxk1 = i; }
            }
        }
        if (maxi1 != -1 && maxk1 != -1)
        {
            int[,] b = new int[B.GetLength(0) + 1, B.GetLength(1)];
            for (int i = 0; i < maxi1 + 1; i++)
            {
                for (int j = 0; j < B.GetLength(1); j++) b[i, j] = B[i, j];
            }
            for (int i = 0; i < C.GetLength(0); i++) b[maxi1 + 1, i] = C[i, maxk1];
            for (int k = maxi1 + 1; k < B.GetLength(0); k++)
            {
                for (int h = 0; h < B.GetLength(1); h++) b[k + 1, h] = B[k, h];
            }
            B = b;
        }
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        // create and use SumPositiveElementsInColumns(matrix);
        static int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return null;
            int row = matrix.GetLength(0), column = matrix.GetLength(1);
            int[] x = new int[column];
            for (int i = 0; i < column; i++)
            {
                int s = 0;
                for (int k = 0; k < row; k++)
                {
                    if (matrix[k, i] > 0) s += matrix[k, i];
                }
                x[i] = s;
            }
            return x;
        }
        int[] sA = SumPositiveElementsInColumns(A), sC = SumPositiveElementsInColumns(C);
        if (sA == null || sC == null || sA.Length == 0 || sC.Length == 0) return null;
        answer = new int[sA.Length + sC.Length];
        int y = 0;
        for (int i = 0; i < sA.Length; i++) answer[y++] = sA[i];
        for (int k = 0; k < sC.Length; k++) answer[y++] = sC[k];
        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            row = 0; column = 0;
            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max) { max = matrix[i, k]; row = i; column = k; }
                }
            }
        }
        int maxArow, maxAcolumn, maxBrow, maxBcolumn;
        FindMaxIndex(A, out maxArow, out maxAcolumn); FindMaxIndex(B, out maxBrow, out maxBcolumn);
        int temp = A[maxArow, maxAcolumn];
        A[maxArow, maxAcolumn] = B[maxBrow, maxBcolumn];
        B[maxBrow, maxBcolumn] = temp;
        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        if (matrix == null || matrix.Length == 0) return;
        static void FindMaxIndex(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int max = -100;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max) { max = matrix[i, k]; row = i; col = k; }
                }
            }
        }
        static void FindMinIndex(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int min = 100;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] < min) { min = matrix[i, k]; row = i; col = k; }
                }
            }
        }
        // create and use RemoveRow(matrix, rowIndex);
        static int[,] RemoveRow(int[,] matrix, int rowIndex)
        {
            int row = matrix.GetLength(0), column = matrix.GetLength(1);
            int[,] newMatrix = new int[row - 1, column];
            for (int i = 0, newRow = 0; i < row; i++)
            {
                if (i != rowIndex)
                {
                    for (int k = 0; k < column; k++) newMatrix[newRow, k] = matrix[i, k];
                    newRow++;
                }
            }
            return newMatrix;
        }
        FindMaxIndex(matrix, out int maxrow, out int maxcolumn); FindMinIndex(matrix, out int minrow, out int mincolumn);
        if (maxrow == minrow) matrix = RemoveRow(matrix, maxrow);
        else
        {
            matrix = RemoveRow(matrix, maxrow);
            FindMinIndex(matrix, out minrow, out mincolumn);
            matrix = RemoveRow(matrix, minrow);
        }
        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        // create and use GetAverageWithoutMinMax(matrix);
        static double GetAverageWithoutMinMax(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return 0;
            int min = 100, max = -100, a = 0;
            double s = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    int x = matrix[i, k];
                    if (x < min) min = x;
                    if (x > max) max = x;
                    s += x;
                    a++;
                }
            }
            s -= (max + min); a -= 2;
            return s / a;
        }
        double[] sr = new double[3];
        sr[0] = GetAverageWithoutMinMax(A); sr[1] = GetAverageWithoutMinMax(B); sr[2] = GetAverageWithoutMinMax(C);
        if (sr[0] > sr[1] && sr[1] > sr[2]) answer = -1;
        else if (sr[0] < sr[1] && sr[1] < sr[2]) answer = 1;
        else answer = 0;
        // end
        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        static int MaxInRow(int[,] matrix, int i)
        {
            int max = matrix[i, 0];
            for (int k = 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > max) max = matrix[i, k];
            }
            return max;
        }
        // create and use SortRowsByMaxElement(matrix);
        static void SortRowsByMaxElement(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return;
            int row = matrix.GetLength(0);
            if (row <= 1) return;
            int[] rowIndex = new int[row];
            for (int i = 0; i < row; i++) rowIndex[i] = i;
            for (int k = 0; k < row - 1; k++)
            {
                for (int h = 0; h < row - k - 1; h++)
                {
                    if (MaxInRow(matrix, rowIndex[h]) < MaxInRow(matrix, rowIndex[h + 1]))
                    {
                        int temp = rowIndex[h];
                        rowIndex[h] = rowIndex[h + 1];
                        rowIndex[h + 1] = temp;
                    }
                }
            }
            int[,] tempMatrix = new int[row, matrix.GetLength(1)];
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++) tempMatrix[i, k] = matrix[i, k];
            }
            for (int i = 0; i < row; i++)
            {
                int idx = rowIndex[i];
                for (int k = 0; k < matrix.GetLength(1); k++) matrix[i, k] = tempMatrix[idx, k];
            }
        }
        SortRowsByMaxElement(A); SortRowsByMaxElement(B);
        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        if (matrix == null || matrix.GetLength(0) == 0) return;
        // use RemoveRow(matrix, rowIndex); from 2_13
        static int[,] RemoveRow(int[,] matrix, int rowIndex)
        {
            int row = matrix.GetLength(0); int column = matrix.GetLength(1);
            int[,] newmatrix = new int[row - 1, column];
            for (int i = 0, newRow = 0; i < row; i++)
            {
                if (i != rowIndex)
                {
                    for (int k = 0; k < column; k++) newmatrix[newRow, k] = matrix[i, k];
                    newRow++;
                }
            }
            return newmatrix;
        }
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            bool zero = false;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] == 0) { zero = true; break; }
            }
            if (zero) matrix = RemoveRow(matrix, i);
        }
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        static int FindMin(int[,] matrix, int row)
        {
            int min = 100;
            for (int k = row; k < matrix.GetLength(1); k++)
            {
                if (matrix[row, k] < min) min = matrix[row, k];
            }
            return min;
        }
        // create and use CreateArrayFromMins(matrix);
        static int[] CreateArrayFromMins(int[,] matrix)
        {
            int[] s = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++) s[i] = FindMin(matrix, i);
            return s;
        }
        if (A == null || B == null) return;
        answerA = CreateArrayFromMins(A); answerB = CreateArrayFromMins(B);
        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        if (A == null || B == null) return;
        // create and use MatrixValuesChange(matrix);
        static void MatrixValuesChange(double[,] matrix)
        {
            int row = matrix.GetLength(0), column = matrix.GetLength(1);
            double[] values = new double[row * column];
            int[] rowIndex = new int[row * column], columnIndex = new int[row * column];

            int s = 0;
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < column; k++)
                {
                    values[s] = matrix[i, k];
                    rowIndex[s] = i;
                    columnIndex[s] = k;
                    s++;
                }
            }
            for (int i = 0; i < row * column; i++)
            {
                for (int k = 0; k < row * column - i - 1; k++)
                {
                    if (values[k] < values[k + 1])
                    {
                        double tempvalues = values[k];
                        values[k] = values[k + 1];
                        values[k + 1] = tempvalues;

                        int temprow = rowIndex[k];
                        rowIndex[k] = rowIndex[k + 1];
                        rowIndex[k + 1] = temprow;

                        int tempcol = columnIndex[k];
                        columnIndex[k] = columnIndex[k + 1];
                        columnIndex[k + 1] = tempcol;
                    }
                }
            }
            for (int i = 0; i < row * column; i++)
            {
                if (i < 5 && matrix[rowIndex[i], columnIndex[i]] > 0) matrix[rowIndex[i], columnIndex[i]] *= 2;
                else if (i < 5 && matrix[rowIndex[i], columnIndex[i]] < 0) matrix[rowIndex[i], columnIndex[i]] /= 2;
                else if (i >= 5 && matrix[rowIndex[i], columnIndex[i]] > 0) matrix[rowIndex[i], columnIndex[i]] /= 2;
                else matrix[rowIndex[i], columnIndex[i]] *= 2;
            }
        }
        MatrixValuesChange(A); MatrixValuesChange(B);
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                if (matrix[rowIndex, k] < 0) count++;
            }
            return count;
        }
        // create and use FindRowWithMaxNegativeCount(matrix);
        static int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int maxcount = 0, maxrowi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int negcount = CountNegativeInRow(matrix, i);
                if (negcount > maxcount) { maxcount = negcount; maxrowi = i; }
            }
            return maxrowi;
        }
        maxA = FindRowWithMaxNegativeCount(A); maxB = FindRowWithMaxNegativeCount(B);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        if (A == null && B == null) return;
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        static bool FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
        {
            int max = -100;
            columnIndex = -1;
            bool s = false;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                if (matrix[rowIndex, k] > max)
                {
                    max = matrix[rowIndex, k];
                    columnIndex = k;
                    s = true;
                }
            }
            return s;
        }
        // create and use ReplaceMaxElementOdd(matrix, row, column); íå÷åòíûé
        static void ReplaceMaxElementOdd(int[,] matrix, int row, int column)
        {
            matrix[row, column] *= (column + 1);
        }
        // create and use ReplaceMaxElementEven(matrix, row, column);
        static void ReplaceMaxElementEven(int[,] matrix, int row, int column)
        {
            matrix[row, column] = 0;
        }
        static void Replace(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int columnIndex;
                if (FindRowMaxIndex(matrix, i, out columnIndex))
                {
                    if ((i + 1) % 2 == 0) ReplaceMaxElementEven(matrix, i, columnIndex);
                    else ReplaceMaxElementOdd(matrix, i, columnIndex);
                }
            }
        }
        Replace(A); Replace(B);
        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
