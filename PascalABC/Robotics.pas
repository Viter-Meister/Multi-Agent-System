unit Robotics;

interface

uses TCPServer;

var fServer := new ServerObj('192.168.31.133', 8888);
var fServer1 := new ServerObj('192.168.31.133', 9999);

/// <summary>
/// Класс для управления дифференциальным приводом
/// </summary>  
type 
  RobotDiffeDrive = class
  private
    fName: string;
    
    function GetLinear: double;
    function GetAngular: double;
    
    function IsRunning: boolean;
  public
    constructor Create(Name: string);
      begin
        fName := Name;
      end;
  
    /// Задать линейную скорость
    procedure SetLinearSpeed(speed: double);
    /// Задать угловую скорость
    procedure SetAngularSpeed(speed: double);
    
    /// Установить линейную и угловую скорость в 0
    procedure Stop();
    
    ///  Текущая линейная скорость
    property LinearSpeed : double read GetLinear;
    ///  Текущая угловая скорость
    property AngularSpeed : double read GetAngular;
    ///  Задана ли линейная или угловая скорость
    property Running : boolean read IsRunning;
  end;

/// <summary>
/// Класс робота
/// </summary>  
type
  Robot = class
  private
    fName: string;
    fDiffeDrive: RobotDiffeDrive;
  public
    constructor Create(Name: string);
    begin
      fName := Name;
      fDiffeDrive := new RobotDiffeDrive(Name);
    end;
    
    /// Имя робота
    property Name: string read fName;
    /// Дифферинциальный привод робота
    property DiffeDrive: RobotDiffeDrive read fDiffeDrive;
    
    /// Сдвинуть робота вперед
    procedure MoveForward();
    /// Сдвинуть робота назад
    procedure MoveBack();
    /// Повернуть робота влево
    procedure TurnLeft();
    /// Повернуть робота вправо
    procedure TurnRight();
    
    /// Выполненить команды
    procedure DoCommand();
  end;

//----------------Реализация методов робота----------------//
implementation

procedure Robot.MoveForward();
begin
  var command := $'ROBOT:{fName},OPERATION:MOVE_FORWARD;';
  fServer.AddCommand(command);
end;

procedure Robot.MoveBack();
begin
  var command := $'ROBOT:{fName},OPERATION:MOVE_BACK;';
  fServer.AddCommand(command);
end;

procedure Robot.TurnLeft();
begin
  var command := $'ROBOT:{fName},OPERATION:TURN_LEFT;';
  fServer.AddCommand(command);
end;

procedure Robot.TurnRight();
begin
  var command := $'ROBOT:{fName},OPERATION:TURN_RIGHT;';
  fServer.AddCommand(command);
end;

procedure Robot.DoCommand();
begin
  fServer.SendCommand();
end;

//----------------Реализация методов дифференциального привода----------------//
procedure RobotDiffeDrive.SetLinearSpeed(speed: double);
begin
  var command := $'ROBOT:{fName},OPERATION:SET_LINEAR,VALUE:{speed};';
  fServer.AddCommand(command);
end;

procedure RobotDiffeDrive.SetAngularSpeed(speed: double);
begin
  var command := $'ROBOT:{fName},OPERATION:SET_ANGULAR,VALUE:{speed};';
  fServer.AddCommand(command);
end;

procedure RobotDiffeDrive.Stop();
begin
  var command := $'ROBOT:{fName},OPERATION:STOP';
  fServer.AddCommand(command);
end;

function RobotDiffeDrive.GetLinear(): double;
begin
  var command := $'ROBOT:{fName},OPERATION:GET_LINEAR';
  fServer.AddCommand(command);
  fServer.SendCommand();
  var data := fServer1.GetFeedback();
  var res := double.Parse(data.Result);
  Result := res;
end;

function RobotDiffeDrive.GetAngular(): double;
begin
  var command := $'ROBOT:{fName},OPERATION:GET_ANGULAR';
  fServer.AddCommand(command);
  fServer.SendCommand();
  var data := fServer1.GetFeedback();
  //Console.WriteLine(data.Result);
  var res := double.Parse(data.Result);
  Result := res;
end;

function RobotDiffeDrive.IsRunning(): boolean;
begin
  var command := $'ROBOT:{fName},OPERATION:IS_RUNNING';
  fServer.AddCommand(command);
  fServer.SendCommand();
  var data := fServer1.GetFeedback();
  Result := data.Result = 'true'? true :false;
end;

end.