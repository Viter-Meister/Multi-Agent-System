import os
from launch import LaunchDescription
from launch.actions import DeclareLaunchArgument, IncludeLaunchDescription, ExecuteProcess
from launch.conditions import IfCondition, UnlessCondition
from launch.launch_description_sources import PythonLaunchDescriptionSource
from launch.substitutions import Command, LaunchConfiguration, PythonExpression
from launch_ros.actions import Node
from launch_ros.substitutions import FindPackageShare

def generate_launch_description():

  # Set the path to different files and folders.
  pkg_share = FindPackageShare(package='pascal_tcp_command_receiver').find('pascal_tcp_command_receiver')
  default_launch_dir = os.path.join(pkg_share, 'launch')
    
  start_pascal_command_subscriber = Node(
    package='pascal_tcp_command_receiver',
    executable='PascalCommandSubscriberNode',
    name='pascal_command_subscriber')
    
  start_pascal_command_formatting = Node(
    package='pascal_tcp_command_receiver',
    executable='PascalFormattingCommandNode',
    name='pascal_command_formatting')
    
  start_robot_controller = Node(
    package='pascal_tcp_command_receiver',
    executable='RobotControllerNode',
    name='robot_controller')
		
  # Create the launch description and populate
  ld = LaunchDescription()

  ld.add_action(start_robot_controller)
  ld.add_action(start_pascal_command_formatting)
  ld.add_action(start_pascal_command_subscriber)

  return ld
