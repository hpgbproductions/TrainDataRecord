using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanuden.Rudolf;
using Tanuden.Rudolf.Enums;
using Tanuden.Rudolf.Adapters.Bve;
using Tanuden.Rudolf.Adapters.TrainCrew;
using Tanuden.Rudolf.Sections;

namespace TrainDataRecorder
{
    partial class Form1
    {
        /// <summary>
        /// Signals that the recorder should be stopped (RecorderModes.Disabled), or is running in a game (other values).
        /// </summary>
        public enum RecorderModes
        {
            Disabled,
            TrainCrew,
            BVE
        }

        public enum DataField
        {
            time_sim,
            time_elapsed,
            time_tick,
            diagram_trainNumber,
            diagram_boundFor,
            diagram_serviceType,
            diagram_direction,
            diagram_runNumber,
            stations_currentIndex,
            stations_nextIndex,
            stations_next_name,
            stations_next_fromStartDistance,
            stations_next_absoluteDistance,
            stations_next_doorSide,
            stations_next_stopType,
            stations_next_arrival,
            stations_next_departure,
            stations_next_stopPositionName,
            stations_next_isTimeTaken,
            physics_speed,
            physics_fromStartDistance,
            physics_absoluteDistance,
            physics_gradient,
            physics_mrPressure,
            controllers_powerNotch,
            controllers_brakeNotch,
            controllers_reverser,
            controllers_ato_active,
            controllers_ato_notch,
            controllers_tasc_active,
            controllers_tasc_notch,
            controllers_tasc_inching,
            controllers_deadman,
            doors_allClosed,
            doors_perCar_carNo,
            doors_perCar_sideOpened,
            lamps_doorClose,
            lamps_atsReady,
            lamps_atsBrakeApply,
            lamps_atsOpen,
            lamps_regenerative,
            lamps_ebTimer,
            lamps_emergencyBrake,
            lamps_overload,
            lamps_pilot,
            lamps_ato,
            ats_class,
            ats_speed,
            ats_state,
            signals_next_name,
            signals_next_type,
            signals_next_phase,
            signals_next_distance,
            speedLimit_current,
            speedLimit_currentType,
            speedLimit_next,
            speedLimit_next_distance,
            speedLimit_next_type,
            cars_carNo,
            cars_bcPressure,
            cars_amperage,
            cars_occupancyRate,
            switches_hornAir,
            switches_hornElectric,
            switches_buzzerDriver,
            switches_buzzerConductor,
            switches_headlights,
            switches_highBeam,
            switches_wiper
        }

        /// <summary>
        /// Wrapper for ToString methods of different types.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="numberFormatInfo"></param>
        /// <returns></returns>
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
                    return (string)obj;
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
                    // Other types, simply use the default ToString
                    // Enums are converted to their string names
                    return obj.ToString();
                }
            }
        }

        /// <summary>
        /// Generate the string corresponding to a specified data field.
        /// </summary>
        /// <param name="frame">Data frame to use.</param>
        /// <param name="dataField">Selected information to read.</param>
        /// <returns></returns>
        public string GetDataString(OutputDataFrame frame, DataField dataField, int numCars, bool euMode, NumberFormatInfo numberFormatInfo)
        {
            
            object? result;
            Type rt = typeof(string);

            bool stationListLoaded = frame.Stations.List.Count > 0;
            bool doorListLoaded = frame.Doors.PerCar.Count > 0;
            bool signalListLoaded = frame.Signals.List.Count > 0;
            bool speedLimitListLoaded = frame.SpeedLimit.Next != null && frame.SpeedLimit.Next.Count > 0;
            bool carListLoaded = frame.Cars.List.Count > 0;

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
                    result = stationListLoaded ? frame.Stations.List[0].Name : "";
                    rt = typeof(string);
                    break;
                case DataField.stations_next_fromStartDistance:
                    result = stationListLoaded ? frame.Stations.List[0].FromStartDistance : 0;
                    rt = typeof(double);
                    break;
                case DataField.stations_next_absoluteDistance:
                    result = stationListLoaded ? frame.Stations.List[0].AbsoluteDistance : 0;
                    rt = typeof(double);
                    break;
                case DataField.stations_next_doorSide:
                    result = stationListLoaded ? frame.Stations.List[0].DoorSide : 0;
                    rt = typeof(int);
                    break;
                case DataField.stations_next_stopType:
                    result = stationListLoaded ? frame.Stations.List[0].StopType : "";
                    rt = typeof(StopType);
                    break;
                case DataField.stations_next_arrival:
                    result = stationListLoaded ? frame.Stations.List[0].Arrival : "";
                    rt = typeof(string);
                    break;
                case DataField.stations_next_departure:
                    result = stationListLoaded ? frame.Stations.List[0].Departure : "";
                    rt = typeof(string);
                    break;
                case DataField.stations_next_stopPositionName:
                    result = stationListLoaded ? frame.Stations.List[0].StopPositionName : "";
                    rt = typeof(string);
                    break;
                case DataField.stations_next_isTimeTaken:
                    result = stationListLoaded ? frame.Stations.List[0].IsTimeTaken : null;
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
                case DataField.physics_gradient:
                    result = frame.Physics.Gradient;
                    rt = typeof(double);
                    break;
                case DataField.physics_mrPressure:
                    result = frame.Physics.MrPressure;
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
                            if (i < frame.Doors.PerCar.Count)
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
                            if (i < frame.Doors.PerCar.Count)
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
                    result = frame.Lamps.Values.ContainsKey("doorClose") ? frame.Lamps.Values["doorClose"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsReady:
                    result = frame.Lamps.Values.ContainsKey("atsReady") ? frame.Lamps.Values["atsReady"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsBrakeApply:
                    result = frame.Lamps.Values.ContainsKey("atsBrakeApply") ? frame.Lamps.Values["atsBrakeApply"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_atsOpen:
                    result = frame.Lamps.Values.ContainsKey("atsOpen") ? frame.Lamps.Values["atsOpen"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_regenerative:
                    result = frame.Lamps.Values.ContainsKey("regenerative") ? frame.Lamps.Values["regenerative"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_ebTimer:
                    result = frame.Lamps.Values.ContainsKey("ebTimer") ? frame.Lamps.Values["ebTimer"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_emergencyBrake:
                    result = frame.Lamps.Values.ContainsKey("emergencyBrake") ? frame.Lamps.Values["emergencyBrake"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_overload:
                    result = frame.Lamps.Values.ContainsKey("overload") ? frame.Lamps.Values["overload"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_pilot:
                    result = frame.Lamps.Values.ContainsKey("pilot") ? frame.Lamps.Values["pilot"] : null;
                    rt = typeof(int);
                    break;
                case DataField.lamps_ato:
                    result = frame.Lamps.Values.ContainsKey("ato") ? frame.Lamps.Values["ato"] : null;
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
                    result = signalListLoaded ? frame.Signals.List[0].Name : null;
                    rt = typeof(string);
                    break;
                case DataField.signals_next_type:
                    result = signalListLoaded ? frame.Signals.List[0].Type : null;
                    rt = typeof(SignalType);
                    break;
                case DataField.signals_next_phase:
                    result = signalListLoaded ? frame.Signals.List[0].Phase : null;
                    rt = typeof(int);
                    break;
                case DataField.signals_next_distance:
                    result = signalListLoaded ? frame.Signals.List[0].Distance : null;
                    rt = typeof(double);
                    break;

                case DataField.speedLimit_current:
                    result = frame.SpeedLimit.Current;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_currentType:
                    result = frame.SpeedLimit.CurrentType;
                    rt = typeof(SpeedLimitType);
                    break;
                case DataField.speedLimit_next:
                    result = speedLimitListLoaded ? frame.SpeedLimit.Next[0].Limit : null;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_next_distance:
                    result = speedLimitListLoaded ? frame.SpeedLimit.Next[0].Distance : null;
                    rt = typeof(double);
                    break;
                case DataField.speedLimit_next_type:
                    result = speedLimitListLoaded ? frame.SpeedLimit.Next[0].Type : null;
                    rt = typeof(SpeedLimitType);
                    break;

                case DataField.cars_carNo:
                    if (carListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Cars.List.Count)
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
                    }
                    else
                    {
                        result = null;
                    }
                    rt = typeof(string);
                    break;
                case DataField.cars_bcPressure:
                    if (carListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Cars.List.Count)
                            {
                                result += DataToString(frame.Cars.List[i].BcPressure, typeof(double), numberFormatInfo);
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
                case DataField.cars_amperage:
                    if (carListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Cars.List.Count)
                            {
                                result += DataToString(frame.Cars.List[i].Amperage, typeof(double), numberFormatInfo);
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
                case DataField.cars_occupancyRate:
                    if (carListLoaded)
                    {
                        result = "";
                        for (int i = 0; i < numCars; i++)
                        {
                            if (i < frame.Cars.List.Count)
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
                    }
                    else
                    {
                        result = null;
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
