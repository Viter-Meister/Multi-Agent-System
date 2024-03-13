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
    
    function MoveForward(): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:MOVE_FORWARD;';
    end;
    
    function MoveBack(): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:MOVE_BACK;';
    end;
    
    function TurnLeft(): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:TURN_LEFT;';
    end;
    
    function TurnRight(): string;
    begin
      Result := $'ROBOT:{fName},OPERATION:TURN_RIGHT;';
    end;
  end;
  
end.