
using namespace std;
using System;

class Program {
	static int GetLeadBitNum(int Val) {
		int BitNum = 31;
		uint CmpVal = 1u << BitNum;
		while (Val < CmpVal) {
			CmpVal >>= 1;
			BitNum--;
		}
		return BitNum;
	}

	static int DividePolynomMod(int dividend, int divider) {
		int m = GetLeadBitNum(divider);
		int k = GetLeadBitNum(dividend) - m;
		int remainder;

		if (k < 0) {
			return dividend;
		}
		while (k >= 0) {
			int divider_tmp = divider << k;
			dividend = dividend ^ divider_tmp;
			k = GetLeadBitNum(dividend) - m;
		}
		return dividend;
	}
}


static void Main() {
	int g, e, m, c, s, tlen, tc_, tm_, c_;
	string tb, tc, tm;

	Console.WriteLine("������� g(x)");
	g = Convert.ToInt32(Console.ReadLine(), 2);

	Console.WriteLine("������� m");
	m = Convert.ToInt32(Console.ReadLine(), 2);

	// ��������� ������� ������
	Random rnd = new Random();
	e = rnd.Next(0, 127);
	Console.WriteLine("����������� �����:\ne = " + Convert.ToString(e, 2));

	m = m << GetLeadBitNum(g);

	c = DividePolynomMod(m, g);
	Console.WriteLine("����������� �����:\n� = " + Convert.ToString(c, 2));

	m = m | c;
	Console.WriteLine("�� ������ ������:\na = " + Convert.ToString(m, 2));

	m = m ^ e;
	tb = Convert.ToString(m, 2);
	tlen = (tb.Length / 2) - 1;
	tm = new string(tb.Take(tlen).ToArray());
	tc = new string(tb.Take(2..^0).ToArray());
	Console.WriteLine("�� ������ ������:\nb = " + Convert.ToString(m, 2));

	s = DividePolynomMod(m, g);
	Console.WriteLine("�������:\n s = " + Convert.ToString(s, 2));
	if (s == 0) {
		Console.WriteLine("E = 0, ������ �� ����������");
	}
	else {
		Console.WriteLine("E = 1, ������ ����������");
	}
}