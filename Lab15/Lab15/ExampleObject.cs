namespace Lab15;

public class ExampleObject : IDisposable
{

    // To detect redundant calls
    private bool _disposedValue;

    private String _name;

    public ExampleObject(String name)
    {
        this._name = name;
    }

    ~ExampleObject() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        Console.WriteLine("Dispose method call for the " + ToString());
        
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    public override string ToString()
    {
        return $"ExampleObject[name='{_name}']";
    }

}
