using System;
using Core.Application.Enums;

namespace Endpoint.Models;

public record CreateTaskViewModel(string title, TaskEntityStatus Status, DateOnly? checkoutDate);
