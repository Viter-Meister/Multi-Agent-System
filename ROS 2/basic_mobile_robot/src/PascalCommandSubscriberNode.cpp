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

	public:
	PascalCommandSubscriberNode(): Node("pascal_command_subscriber_node")
	{
		boost::asio::io_service io_service;
		tcp::socket socket(io_service);
		socket.connect(tcp::endpoint(boost::asio::ip::address::from_string("192.168.31.132"), 8888));

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
};

int main(int argc, char * argv[])
{
	rclcpp::init(argc, argv);
	rclcpp::spin(std::make_shared<PascalCommandSubscriberNode>());
	rclcpp::shutdown();
	return 0;
}
