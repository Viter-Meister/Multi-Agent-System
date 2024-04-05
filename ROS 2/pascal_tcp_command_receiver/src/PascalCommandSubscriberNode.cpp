#include <chrono>
#include <functional>
#include <memory>
#include <string>
#include <boost/asio.hpp>
#include "rclcpp/rclcpp.hpp"
#include "std_msgs/msg/string.hpp"

using namespace std::chrono_literals;
using namespace std;
using namespace boost::asio;
using ip::tcp;

class PascalCommandSubscriberNode : public rclcpp::Node
{
	private:
	rclcpp::Publisher<std_msgs::msg::String>::SharedPtr publisher_;
	rclcpp::TimerBase::SharedPtr timer_;

	public:
	PascalCommandSubscriberNode(): Node("pascal_command_subscriber_node")
	{
		this->declare_parameter("ip", "127.0.0.1");
		timer_ = this->create_wall_timer(
      		500ms, std::bind(&PascalCommandSubscriberNode::connection_callback, this));
	}
	
	void connection_callback()
	{
		std::string ip = this->get_parameter("ip").as_string();
		RCLCPP_INFO(this->get_logger(), "IP: %s", ip.c_str());
		
		boost::asio::io_service io_service;
		tcp::socket socket(io_service);
		try
		{
			socket.connect(tcp::endpoint(boost::asio::ip::address::from_string(ip), 8888));
			
			boost::asio::streambuf receive_buffer;
			boost::system::error_code error;
			boost::asio::read(socket, receive_buffer, boost::asio::transfer_all(), error);

			auto message = std_msgs::msg::String();

			if(error && error != boost::asio::error::eof)
				RCLCPP_ERROR(this->get_logger(), "Exception: %s", error.message().c_str());
			else
				message.data = boost::asio::buffer_cast<const char*>(receive_buffer.data());

			publisher_ = this->create_publisher<std_msgs::msg::String>("get_command", 10);
			RCLCPP_INFO(this->get_logger(), "Publishing: '%s'", message.data.c_str());
			publisher_->publish(message);
		}
		catch (boost::system::system_error const& e)
		{
			RCLCPP_INFO(this->get_logger(), "Warning: could not connect : '%s'", e.what());
		}
	}
};

int main(int argc, char * argv[])
{
	rclcpp::init(argc, argv);
	rclcpp::spin(std::make_shared<PascalCommandSubscriberNode>());
	rclcpp::shutdown();
	return 0;
}
