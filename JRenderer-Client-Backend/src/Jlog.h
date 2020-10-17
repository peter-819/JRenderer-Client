#pragma once
#pragma warning (disable:4251)
#include <Jpch.h>

#include <spdlog/spdlog.h>
#include "spdlog/fmt/ostr.h" 

class Log
{
public:
	static void Init();

	inline static std::shared_ptr<spdlog::logger>& GetCoreLogger() { return s_CoreLogger; }
	inline static std::shared_ptr<spdlog::logger>& GetClientLogger() { return s_ClientLogger; }

private:
	static std::shared_ptr<spdlog::logger> s_CoreLogger;
	static std::shared_ptr<spdlog::logger> s_ClientLogger;
};

#define JR_ERROR(...)    ::Log::GetCoreLogger()->error(__VA_ARGS__)
#define JR_WARN(...)     ::Log::GetCoreLogger()->warn(__VA_ARGS__)
#define JR_INFO(...)     ::Log::GetCoreLogger()->info(__VA_ARGS__)
#define JR_TRACE(...)    ::Log::GetCoreLogger()->trace(__VA_ARGS__)
#define JR_FATAL(...)    ::Log::GetCoreLogger()->fatal(__VA_ARGS__)

#define JE_CLIENT_ERROR(...)    ::Log::GetClientLogger()->error(__VA_ARGS__)
#define JE_CLIENT_WARN(...)     ::Log::GetClientLogger()->warn(__VA_ARGS__)
#define JE_CLIENT_INFO(...)     ::Log::GetClientLogger()->info(__VA_ARGS__)
#define JE_CLIENT_TRACE(...)    ::Log::GetClientLogger()->trace(__VA_ARGS__)
#define JE_CLIENT_FATAL(...)    ::Log::GetClientLogger()->fatal(__VA_ARGS__)
