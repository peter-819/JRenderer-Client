#include <Jpch.h>

#include <jpeglib.h>
#include <stdio.h>
#include <setjmp.h>
#define JPEG_LIB_VERSION 62

JAPI void DecompressJPEG(unsigned char* inBuffer,int inSize, unsigned char** outBuffer,
									int *outSize, int *width, int *height, int *components) 
{
	struct jpeg_decompress_struct cinfo;
	struct jpeg_error_mgr jerr;

	JSAMPROW row_pointer[1];
	int row_stride;

	cinfo.err = jpeg_std_error(&jerr);

	jpeg_create_decompress(&cinfo);
	jpeg_mem_src(&cinfo, inBuffer, inSize);
	jpeg_read_header(&cinfo, TRUE);
	jpeg_start_decompress(&cinfo);

	*width = cinfo.image_width;
	*height = cinfo.image_height;
	*components = cinfo.output_components;

	row_stride = cinfo.output_width * cinfo.output_components;
	
	*outSize = (*width) * (*height) * (*components);
	*outBuffer = (unsigned char*)malloc(*outSize);

	while (cinfo.output_scanline < cinfo.output_height) {
		unsigned char* buffer_array[1];
		buffer_array[0] = *outBuffer + (cinfo.output_scanline) * row_stride;
		jpeg_read_scanlines(&cinfo, buffer_array, 1);
	}
	jpeg_finish_decompress(&cinfo);
	jpeg_destroy_decompress(&cinfo);
	return;
}