unit TCPServer;

interface

uses System, System.Net, System.Net.Sockets, System.IO, System.Threading.Tasks;

type
  ServerObj = class
  private
    localAddr: IPAddress;
    ipLocalEndPoint: IPEndPoint;
    listener: TcpListener;
    client: TCPClient;  
    queries: Queue<string>;
  public
    constructor Create(ip: string; port: integer);
    begin
      queries := new Queue<string>();      
      localAddr := IPAddress.Parse(ip);
      ipLocalEndPoint := new IPEndPoint(localAddr, port);
      listener := new TcpListener(ipLocalEndPoint);
      Console.WriteLine($'Создан сервер: {listener.LocalEndpoint}');
    end;
    
    async function Start(): Task;
    procedure Send(message: string);
    procedure Disconnect();
  end;

implementation

async function ServerObj.Start(): Task;
begin
  try
    // запускаем сервер
    listener.Start();
    Console.WriteLine('Сервер запущен. Ожидание подключения...');
    
    // получаем входящее подключение
    var tcpClient := await listener.AcceptTcpClientAsync();
    client := tcpClient.Result;
    // получаем объект NetworkStream для взаимодействия с клиентом
    var stream := client.GetStream();
    // получаем адрес клиента
    Console.WriteLine($'Входящее подключение: {client.Client.RemoteEndPoint}');
    
    while true do
    begin
      if queries.Count() = 0 then
      begin
        Disconnect();
        break;
      end
      else
      begin
        // определяем данные для отправки
        var data := Encoding.UTF8.GetBytes(queries.Dequeue());
        // отправляем данные
        var wr := await stream.WriteAsync(data, 0, data.Length);
        Console.WriteLine($'Клиенту {client.Client.RemoteEndPoint} отправлены данные');
      end;
    end;
  finally
    Console.WriteLine($'Подключение прервано.');
    Disconnect();
  end;
end;

procedure ServerObj.Send(message: string);
begin
  queries.Enqueue(message);
end;

procedure ServerObj.Disconnect();
begin
  client.Close();
  listener.Stop();
end;

end.