

Robot robot = new();

robot.Commands[0] = new OnCommand();
robot.Commands[1] = new NorthCommand();
robot.Commands[2] = new WestCommand();
robot.Commands[3] = new OffCommand();

robot.MainRun();
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[4];

    public void MainRun()
    {
        foreach (RobotCommand? command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X}, {Y}, {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);

}


public class OnCommand : RobotCommand { public override void Run(Robot robot) { robot.IsPowered = true; } }
public class OffCommand : RobotCommand { public override void Run(Robot robot) { robot.IsPowered = false; } }

public class NorthCommand : RobotCommand{ public override void Run(Robot robot) { if (robot.IsPowered) { robot.Y++; } }}
public class SouthCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered) { robot.Y--; } } }
public class WestCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered) { robot.X--; } } }
public class EastCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered) { robot.X++; } } }