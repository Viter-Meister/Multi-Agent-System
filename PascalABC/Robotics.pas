unit Robotics;

type
  Robot = class
  private
    fName: string;
  public
    constructor Create(Name: string);
    begin
      fName := Name;
    end;
    
    property Name: string read fName;
    
    function CreateRobot(): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:CREATE;';
    end;
    
    function MoveForward(distance: integer): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:MOVE_FORWARD,VALUE:{distance};';
    end;
    
    function MoveBack(distance: integer): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:MOVE_BACK,VALUE:{distance};';
    end;
    
    function TurnLeft(angle: integer): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:TURN_LEFT,VALUE:{angle};';
    end;
    
    function TurnRight(angle: integer): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:TURN_RIGHT,VALUE:{angle};';
    end;
  end;
  
end.