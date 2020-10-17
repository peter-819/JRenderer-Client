#pragma once
#include "D3DInclude.h"
#include "RenderSystem/Device.h"

namespace JRenderer {
	class D3Device : public Device {
	public:
		D3Device(){}
		virtual ~D3Device(){}
		virtual void Clear(float r, float g, float b, float a) override;
		virtual void SetViewport(int x, int y, int width, int height)override;

	private:
		void EnableDebugLayer();
		void UpdateRenderTargetViews();

	private:
		static constexpr int g_NumFrames = 2;
		bool g_VSync = true;
		bool g_TearingSupported = false;
		bool g_Fullscreen = false;

		ComPtr<ID3D12Device2> mDevice;
		ComPtr<ID3D12CommandQueue> mCommandQueue;
		ComPtr<IDXGISwapChain4> mSwapChain;
		ComPtr<ID3D12Resource> mBackBuffers[g_NumFrames];
		ComPtr<ID3D12GraphicsCommandList> mCommandList;
		ComPtr<ID3D12CommandAllocator> mCommandAllocators[g_NumFrames];
		ComPtr<ID3D12DescriptorHeap> mRTVDescriptorHeap;
		UINT mRTVDescriptorSize;
		UINT mCurrentBackBufferIndex;
	};
}