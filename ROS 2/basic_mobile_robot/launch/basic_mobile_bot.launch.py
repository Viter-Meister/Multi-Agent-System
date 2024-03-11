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
  pkg_share = FindPackageShare(package='basic_mobile_robot').find('basic_mobile_robot')
  default_launch_dir = os.path.join(pkg_share, 'launch')
  default_model_path = os.path.join(pkg_share, 'models/basic_mobile_bot.urdf')
  robot_name_in_urdf = 'basic_mobile_bot'
  default_rviz_config_path = os.path.join(pkg_share, 'rviz/urdf_config.rviz')
  
  # Launch configuration variables specific to simulation
  model = LaunchConfiguration('model')
  rviz_config_file = LaunchConfiguration('rviz_config_file')
  use_robot_state_pub = LaunchConfiguration('use_robot_state_pub')
  use_rviz = LaunchConfiguration('use_rviz')
  use_sim_time = LaunchConfiguration('use_sim_time')

  # Declare the launch arguments  
  declare_model_path_cmd = DeclareLaunchArgument(
    name='model', 
    default_value=default_model_path, 
    description='Absolute path to robot urdf file')
    
  declare_rviz_config_file_cmd = DeclareLaunchArgument(
    name='rviz_config_file',
    default_value=default_rviz_config_path,
    description='Full path to the RVIZ config file to use')
  
  declare_use_robot_state_pub_cmd = DeclareLaunchArgument(
    name='use_robot_state_pub',
    default_value='True',
    description='Whether to start the robot state publisher')

  declare_use_rviz_cmd = DeclareLaunchArgument(
    name='use_rviz',
    default_value='True',
    description='Whether to start RVIZ')
    
  declare_use_sim_time_cmd = DeclareLaunchArgument(
    name='use_sim_time',
    default_value='True',
    description='Use simulation (Gazebo) clock if true')
   
  # Specify the actions

  # Publish the joint state values for the non-fixed joints in the URDF file.
  start_joint_state_publisher_cmd = Node(
    package='joint_state_publisher',
    executable='joint_state_publisher',
    name='joint_state_publisher')

  # Subscribe to the joint states of the robot, and publish the 3D pose of each link.
  start_robot_state_publisher_cmd = Node(
    condition=IfCondition(use_robot_state_pub),
    package='robot_state_publisher',
    executable='robot_state_publisher',
    parameters=[{'use_sim_time': use_sim_time, 
    'robot_description': Command(['xacro ', model])}],
    arguments=[default_model_path])

  # Launch RViz
  start_rviz_cmd = Node(
    condition=IfCondition(use_rviz),
    package='rviz2',
    executable='rviz2',
    name='rviz2',
    output='screen',
    arguments=['-d', rviz_config_file])
    
  spawn_entity = Node(
    package='gazebo_ros',
    executable='spawn_entity.py',
    arguments=['-entity', 'sam_bot', '-topic', 'robot_description'],
    output='screen')
    
  start_gazebo = ExecuteProcess(
    cmd=['gazebo', '--verbose', '-s', 'libgazebo_ros_init.so', '-s', 'libgazebo_ros_factory.so'], 
    output='screen')
    
  start_robot_localization_cmd = Node(
    package='robot_localization',
    executable='ekf_node',
    name='ekf_filter_node',
    output='screen',
    parameters=[os.path.join(pkg_share, 'config/ekf.yaml'), {'use_sim_time':    
    LaunchConfiguration('use_sim_time')}])
		
  # Create the launch description and populate
  ld = LaunchDescription()

  # Declare the launch options
  ld.add_action(declare_model_path_cmd)
  ld.add_action(declare_rviz_config_file_cmd)
  ld.add_action(declare_use_robot_state_pub_cmd)  
  ld.add_action(declare_use_rviz_cmd) 
  ld.add_action(declare_use_sim_time_cmd)
  
  ld.add_action(start_gazebo)

  # Add any actions
  ld.add_action(start_joint_state_publisher_cmd)
  ld.add_action(start_robot_state_publisher_cmd)
  ld.add_action(spawn_entity)
  ld.add_action(start_robot_localization_cmd)
  ld.add_action(start_rviz_cmd)

  return ld
