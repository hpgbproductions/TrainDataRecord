using System;
using System.Collections.Generic;
using System.Globalization;
using Tanuden.Rudolf;
using Tanuden.Rudolf.Enums;

namespace TrainDataRecorder
{
    partial class Form1
    {
        /// <summary>
        /// Wrapper for ToString methods of different types.
        /// Null becomes <c>"null"</c>, empty strings become <c>"empty"</c>.
        /// </summary>
        private string DataToString(object? obj, Type type, NumberFormatInfo numberFormatInfo)
        {
            if (obj == null)
            {
                return "null";
            }
            else
            {
                if (type == typeof(string))
                {
                    string s = (string)obj;
                    return (s == string.Empty) ? "empty" : s;
                }
                else if (type == typeof(int))
                {
                    return ((int)obj).ToString(numberFormatInfo);
                }
                else if (type == typeof(long))
                {
                    return ((long)obj).ToString(numberFormatInfo);
                }
                else if (type == typeof(float))
                {
                    return ((float)obj).ToString(numberFormatInfo);
                }
                else if (type == typeof(double))
                {
                    return ((double)obj).ToString(numberFormatInfo);
                }
                else
                {
                    // Non-basic types, simply use the default ToString.
                    // Enums are converted to their string names
                    string? s = obj.ToString();
                    if (s == null)
                    {
                        return "null";
                    }
                    else if (s == string.Empty)
                    {
                        return "empty";
                    }
                    else
                    {
                        return s;
                    }
                }
            }
        }

        /// <summary>
        /// Generate the string corresponding to a specified data field.
        /// Frame is not null-checked here.
        /// </summary>
        public string GetDataString(OutputDataFrame frame, DataField dataField, int numCars, int numBogiesPerCar, bool euMode, NumberFormatInfo numberFormatInfo)
        {
            // Value to convert into the returned string.
            // Multi-column results are stored as delimited strings without a trailing delimiter.
            object? result;

            // Expected non-nullable type of the result.
            // Multi-column results are modelled as strings.
            Type rt = typeof(string);

            // Non-nullability status of the Doors list
            bool doorListLoaded = frame.Doors.PerCar != null;

            // Non-nullability status of the Cars list
            bool carListLoaded = frame.Cars.List != null;

            int nextStationIndex = frame.Stations.NextIndex.HasValue ? frame.Stations.NextIndex.Value : -1;
            bool nextStationExists =
                frame.Stations.List != null &&
                frame.Stations.NextIndex.HasValue &&
                frame.Stations.NextIndex.Value >= 0 &&
                frame.Stations.NextIndex.Value < frame.Stations.List.Count;

            bool nextSignalExists =
                frame.Signals.List != null &&
                frame.Signals.List.Count >= 1;

            bool nextSpeedLimitExists =
                frame.SpeedLimits.Next != null &&
                frame.SpeedLimits.Next.Count >= 1;

            string itemDelimiter = euMode ? ";" : ",";

            switch (dataField)
            {
                case DataField.time_sim:
                    result = frame.Time.Sim;
                    rt = typeof(string);
                    break;
                case DataField.time_elapsed:
                    result = frame.Time.Elapsed;
                    rt = typeof(double);
                    break;
                case DataField.time_tick:
                    result = frame.Time.Tick;
                    rt = typeof(long);
                    break;

                case DataField.diagram_trainNumber:
                    result = frame.Diagram.TrainNumber;
                    rt = typeof(string);
                    break;
                case DataField.diagram_boundFor:
                    result = frame.Diagram.BoundFor;
                    rt = typeof(string);
                    break;
                case DataField.diagram_serviceType:
                    result = frame.Diagram.ServiceType;
                    rt = typeof(string);
                    break;
                case DataField.diagram_direction:
                    result = frame.Diagram.Direction;
                    rt = typeof(LineDirection);
                    break;
                case DataField.diagram_runNumber:
                    result = frame.Diagram.RunNumber;
                    rt = typeof(string);
                    break;

                case DataField.stations_currentIndex:
                    result = frame.Stations.CurrentIndex;
                    rt = typeof(int);
                    break;
                case DataField.stations_nextIndex:
                    result = frame.Stations.NextIndex;
                    rt = typeof(int);
                    break;
                case DataField.stations_next_name:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].Name : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_fromStartDistance:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].FromStartDistance : null;
                    rt = typeof(double);
                    break;
                case DataField.stations_next_absoluteDistance:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].AbsoluteDistance : null;
                    rt = typeof(double);
                    break;
                case DataField.stations_next_doorSide:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].DoorSide : null;
                    rt = typeof(int);
                    break;
                case DataField.stations_next_stopType:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].StopType : null;
                    rt = typeof(StopType);
                    break;
                case DataField.stations_next_arrival:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].Arrival : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_departure:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].Departure : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_stopPositionName:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].StopPositionName : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_trackSectionName:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].TrackSectionName : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_remarks:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].Remarks : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_entrySpeed:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].EntrySpeed : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_exitSpeed:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].ExitSpeed : null;
                    rt = typeof(string);
                    break;
                case DataField.stations_next_isTimeTaken:
                    result = nextStationExists ? frame.Stations.List![nextStationIndex].IsTimeTaken : null;
                    rt = typeof(bool);
                    break;

                case DataField.physics_speed:
                    result = frame.Physics.Speed;
                    rt = typeof(double);
                    break;
                case DataField.physics_fromStartDistance:
                    result = frame.Physics.FromStartDistance;
                    rt = typeof(double);
                    break;
                case DataField.physics_absoluteDistance:
                    result = frame.Physics.AbsoluteDistance;
                    rt = typeof(double);
                    break;
                case DataField.physics_curveRadius:
                    result = frame.Physics.CurveRadius;
                    rt = typeof(double);
                    break;
                case DataField.physics_gradient:
                    result = frame.Physics.Gradient;
                    rt = typeof(double);
                    break;
                case DataField.physics_mrPressure:
                    result = frame.Physics.MrPressure;
                    rt = typeof(double);
                    break;
                case DataField.physics_totalLoadMass:
                    result = frame.Physics.TotalLoadMass;
                    rt = typeof(double);
                    break;

                case DataField.controllers_powerNotch:
                    result = frame.Controllers.PowerNotch;
                    rt = typeof(int);
                    break;
                case DataField.controllers_brakeNotch:
                    result = frame.Controllers.BrakeNotch;
                    rt = typeof(int);
                    break;
                case DataField.controllers_reverser:
                    result = frame.Controllers.Reverser;
                    rt = typeof(int);
                    break;
                case DataField.controllers_ato_active:
                    result = frame.Controllers.Ato != null ? frame.Controllers.Ato.Active : null;
                    rt = typeof(bool);
                    break;
                case DataField.controllers_ato_notch:
                    result = frame.Controllers.Ato != null ? frame.Controllers.Ato.Notch : null;
                    rt = typeof(int);
                    break;
                case DataField.controllers_tasc_active:
                    result = frame.Controllers.Tasc != null ? frame.Controllers.Tasc.Active : null;
                    rt = typeof(bool);
                    break;
                case DataField.controllers_tasc_notch:
                    result = frame.Controllers.Tasc != null ? frame.Controllers.Tasc.Notch : null;
                    rt = typeof(int);
                    break;
                case DataField.controllers_tasc_inching:
                    result = frame.Controllers.Tasc != null ? frame.Controllers.Tasc.Inching : null;
                    rt = typeof(bool);
                    break;
                case DataField.controllers_deadman:
                    result = frame.Controllers.Deadman;
                    rt = typeof(EBDeadmanMethod);
                    break;

                case DataField.doors_allClosed:
                    result = frame.Doors.AllClosed;
                    rt = typeof(bool);
                    break;
                case DataField.doors_perCar_carNo:
                    if (doorListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Doors.PerCar!.Count)
                            {
                                result += DataToString(frame.Doors.PerCar[i].CarNo, typeof(int), numberFormatInfo);
                            }
                            else
                            {
                                result += "null";
                            }

                            if (i < numCars - 1)
                            {
                                result += itemDelimiter;
                            }
                        }
                    }
                    else
                    {
                        result = null;
                    }
                    rt = typeof(string);
                    break;
                case DataField.doors_perCar_sideOpened:
                    if (doorListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Doors.PerCar!.Count)
                            {
                                result += DataToString(frame.Doors.PerCar[i].SideOpened, typeof(int), numberFormatInfo);
                            }
                            else
                            {
                                result += "null";
                            }

                            if (i < numCars - 1)
                            {
                                result += itemDelimiter;
                            }
                        }
                    }
                    else
                    {
                        result = null;
                    }
                    rt = typeof(string);
                    break;

                case DataField.lamps_doorClose:
                    result = frame.Lamps.Values[0];
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsReady:
                    result = frame.Lamps.Values[1];
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsBrakeApply:
                    result = frame.Lamps.Values[2];
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsOpen:
                    result = frame.Lamps.Values[3];
                    rt = typeof(int);
                    break;
                case DataField.lamps_regenerative:
                    result = frame.Lamps.Values[4];
                    rt = typeof(int);
                    break;
                case DataField.lamps_ebTimer:
                    result = frame.Lamps.Values[5];
                    rt = typeof(int);
                    break;
                case DataField.lamps_emergencyBrake:
                    result = frame.Lamps.Values[6];
                    rt = typeof(int);
                    break;
                case DataField.lamps_overload:
                    result = frame.Lamps.Values[7];
                    rt = typeof(int);
                    break;
                case DataField.lamps_ato:
                    result = frame.Lamps.Values[8];
                    rt = typeof(int);
                    break;
                case DataField.lamps_snowBrake:
                    result = frame.Lamps.Values[9];
                    rt = typeof(int);
                    break;
                case DataField.lamps_wheelSlip:
                    result = frame.Lamps.Values[10];
                    rt = typeof(int);
                    break;

                case DataField.ats_class:
                    result = frame.Ats.Class;
                    rt = typeof(string);
                    break;
                case DataField.ats_speed:
                    result = frame.Ats.Speed;
                    rt = typeof(double);
                    break;
                case DataField.ats_state:
                    result = frame.Ats.State;
                    rt = typeof(string);
                    break;

                case DataField.signals_next_name:
                    result = nextSignalExists ? frame.Signals.List![0].Name : null;
                    rt = typeof(string);
                    break;
                case DataField.signals_next_type:
                    result = nextSignalExists ? frame.Signals.List![0].Type : null;
                    rt = typeof(SignalType);
                    break;
                case DataField.signals_next_phase:
                    result = nextSignalExists ? frame.Signals.List![0].Phase : null;
                    rt = typeof(int);
                    break;
                case DataField.signals_next_distance:
                    result = nextSignalExists ? frame.Signals.List![0].Distance : null;
                    rt = typeof(double);
                    break;

                case DataField.speedLimit_current:
                    result = frame.SpeedLimits.Current;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_currentType:
                    result = frame.SpeedLimits.CurrentType;
                    rt = typeof(SpeedLimitType);
                    break;
                case DataField.speedLimit_next:
                    result = nextSpeedLimitExists ? frame.SpeedLimits.Next![0].Limit : null;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_next_distance:
                    result = nextSpeedLimitExists ? frame.SpeedLimits.Next![0].Distance : null;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_next_type:
                    result = nextSpeedLimitExists ? frame.SpeedLimits.Next![0].Type : null;
                    rt = typeof(SpeedLimitType);
                    break;

                case DataField.cars_carNo:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        if (frame.Cars.List != null && i < frame.Cars.List.Count)
                        {
                            result += DataToString(frame.Cars.List[i].CarNo, typeof(int), numberFormatInfo);
                        }
                        else
                        {
                            result += "null";
                        }

                        if (i < numCars - 1)
                        {
                            result += itemDelimiter;
                        }
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_bogies_position:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        for (int j = 0; j < numBogiesPerCar; j++)
                        {
                            if (frame.Cars.List != null && i < frame.Cars.List!.Count &&
                                frame.Cars.List[i].Bogies != null && j < frame.Cars.List[i].Bogies!.Count)
                            {
                                result += DataToString(frame.Cars.List[i].Bogies![j].Position,
                                    typeof(BogiePosition), numberFormatInfo);
                            }
                            else
                            {
                                result += null;
                            }

                            if (!(i == numCars - 1 && j == numBogiesPerCar - 1))
                            {
                                result += itemDelimiter;
                            }
                        }
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_bogies_bcPressure:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        for (int j = 0; j < numBogiesPerCar; j++)
                        {
                            if (frame.Cars.List != null && i < frame.Cars.List!.Count &&
                                frame.Cars.List[i].Bogies != null && j < frame.Cars.List[i].Bogies!.Count)
                            {
                                result += DataToString(frame.Cars.List[i].Bogies![j].BcPressure,
                                    typeof(double), numberFormatInfo);
                            }
                            else
                            {
                                result += null;
                            }

                            if (!(i == numCars - 1 && j == numBogiesPerCar - 1))
                            {
                                result += itemDelimiter;
                            }
                        }
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_bogies_amperage:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        for (int j = 0; j < numBogiesPerCar; j++)
                        {
                            if (frame.Cars.List != null && i < frame.Cars.List!.Count &&
                                frame.Cars.List[i].Bogies != null && j < frame.Cars.List[i].Bogies!.Count)
                            {
                                result += DataToString(frame.Cars.List[i].Bogies![j].Amperage,
                                    typeof(double), numberFormatInfo);
                            }
                            else
                            {
                                result += null;
                            }

                            if (!(i == numCars - 1 && j == numBogiesPerCar - 1))
                            {
                                result += itemDelimiter;
                            }
                        }
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_occupancyRate:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        if (frame.Cars.List != null && i < frame.Cars.List.Count)
                        {
                            result += DataToString(frame.Cars.List[i].OccupancyRate, typeof(double), numberFormatInfo);
                        }
                        else
                        {
                            result += "null";
                        }

                        if (i < numCars - 1)
                        {
                            result += itemDelimiter;
                        }
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_loadMass:
                    result = "";
                    for (int i = 0; i < numCars; i++)
                    {
                        if (frame.Cars.List != null && i < frame.Cars.List.Count)
                        {
                            result += DataToString(frame.Cars.List[i].LoadMass, typeof(double), numberFormatInfo);
                        }
                        else
                        {
                            result += "null";
                        }

                        if (i < numCars - 1)
                        {
                            result += itemDelimiter;
                        }
                    }
                    rt = typeof(string);
                    break;

                case DataField.switches_hornAir:
                    result = frame.Switches.HornAir;
                    rt = typeof(bool);
                    break;
                case DataField.switches_hornElectric:
                    result = frame.Switches.HornElectric;
                    rt = typeof(bool);
                    break;
                case DataField.switches_buzzerDriver:
                    result = frame.Switches.BuzzerDriver;
                    rt = typeof(bool);
                    break;
                case DataField.switches_buzzerConductor:
                    result = frame.Switches.BuzzerConductor;
                    rt = typeof(bool);
                    break;
                case DataField.switches_headlights:
                    result = frame.Switches.Headlights;
                    rt = typeof(bool);
                    break;
                case DataField.switches_highBeam:
                    result = frame.Switches.HighBeam;
                    rt = typeof(bool);
                    break;
                case DataField.switches_wiper:
                    result = frame.Switches.Wiper;
                    rt = typeof(Wiper);
                    break;

                default:
                    result = "unsupported";
                    rt = typeof(string);
                    break;
            }

            return DataToString(result, rt, numberFormatInfo);
        }
    }
}
