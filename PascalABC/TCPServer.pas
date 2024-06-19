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
    end;
    
    async function SendCommand(): Task;
    async function GetFeedback(): Task<string>;
    procedure AddCommand(message: string);
    procedure Disconnect();
  end;

implementation

async function ServerObj.SendCommand(): Task;
begin
  try
    listener.Start();
    
    var tcpClient := await listener.AcceptTcpClientAsync();
    client := tcpClient.Result;
    var stream := client.GetStream();

    while true do
    begin
      if queries.Count() = 0 then
      begin
        Disconnect();
        break;
      end
      else
      begin
        var data := Encoding.UTF8.GetBytes(queries.Dequeue());
        var wr := await stream.WriteAsync(data, 0, data.Length);
        Console.WriteLine($'Клиенту {client.Client.RemoteEndPoint}' + 
          ' отправлены данные');
      end;
    end;
  finally
    Disconnect();
  end;
end;

async function ServerObj.GetFeedback(): Task<string>;
begin
  try
    // запускаем сервер
    listener.Start();
    
    // получаем входящее подключение
    var tcpClient := await listener.AcceptTcpClientAsync();
    client := tcpClient.Result;
    // получаем объект NetworkStream для взаимодействия с клиентом
    var stream := client.GetStream();

    var data := new byte[512];
    while true do
    begin
      // получаем данные из потока
      var bytes := await stream.ReadAsync(data, 0, 512);
      var message := Encoding.UTF8.GetString(data);
      if bytes.Result > 0 then
      begin
        Console.WriteLine($'Получено сообщение: {message}'); 
        Result := Task.FromResult(message);
        Disconnect();
        break;
      end;
    end;
  finally
    Disconnect();
  end;
end;

procedure ServerObj.AddCommand(message: string);
begin
  queries.Enqueue(message);
end;

procedure ServerObj.Disconnect();
begin
  client.Close();
  listener.Stop();
end;

end.