uses Robotics, TCPServer;

begin  
  var server := new ServerObj('192.168.31.132', 8888);
  
  var robot := new Robot('robot1');
  server.Send(robot.MoveForward());
  server.Send(robot.TurnLeft());
  
  server.Start();
end.