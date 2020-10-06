#include "Jpch.h"
#include "D3Device.h"

namespace JRenderer {
	void D3Device::EnableDebugLayer()
	{
    #if defined(_DEBUG)
         // Always enable the debug layer before doing anything DX12 related
         // so all possible errors generated while creating DX12 objects
         // are caught by the debug layer.
         ComPtr<ID3D12Debug> debugInterface;
         ThrowIfFailed(D3D12GetDebugInterface(IID_PPV_ARGS(&debugInterface)));
         debugInterface->EnableDebugLayer();
    #endif
	}
}