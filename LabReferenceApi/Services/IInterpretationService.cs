using LabReferenceApi.Models.Dtos;

namespace LabReferenceApi.Services;

public interface IInterpretationService
{
    Task<LabResultResponse> InterpretAsync(LabResultRequest request);
    Task<BatchLabResultResponse> InterpretBatchAsync(BatchLabResultRequest request);
}
