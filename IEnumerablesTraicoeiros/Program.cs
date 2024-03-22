using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(BenchmarkColecoesMaterializadas).Assembly).Run(args);

return;

[SimpleJob]
[MemoryDiagnoser]
public class BenchmarkColecoesMaterializadas
{
    [Params(100, 1_000)]
    public int tamanho;

    private List<int> ObterList()
    {
        var lista = new List<int>();

        for (var i = 0; i < tamanho; i++)
            lista.Add(i);

        return lista;
    }

    private IEnumerable<int> ObterYield()
    {
        for (var i = 0; i < tamanho; i++)
            yield return i;
    }

    [Benchmark]
    public int BenchmarkList()
    {
        var sum = 0;

        foreach (var item in ObterList())
            sum += item;

        return sum;
    }

    [Benchmark]
    public int BenchmarkIEnumerable()
    {
        var sum = 0;

        foreach (var item in ObterYield())
            sum += item;

        return sum;
    }
}
