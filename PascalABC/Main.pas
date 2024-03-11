uses Robotics, TCPServer;

begin  
  var server := new ServerObj('192.168.31.133', 8888);
  
  var robot := new Robot('robot1');
  server.Send(robot.CreateRobot());
  server.Send(robot.MoveForward(10));
  server.Send(robot.MoveBack(10));
  
  server.Start();
end.