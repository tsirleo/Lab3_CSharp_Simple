#pragma once
#include "mkl.h"

extern "C"  _declspec(dllexport)
void VM_Sin(MKL_INT n, double* x, double* yHA, double* yEP, double& timeHA, double& timeEP, int& ret);

extern "C"  _declspec(dllexport)
void VM_Cos(MKL_INT n, double* x, double* yHA, double* yEP, double& timeHA, double& timeEP, int& ret);

extern "C"  _declspec(dllexport)
void VM_SinCos(MKL_INT n, double* x, double* yHA, double* yEP, double* zHA, double* zEP, double& timeHA, double& timeEP, int& ret);
