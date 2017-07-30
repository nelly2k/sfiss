import * as React from "react";
import {DropDown, IDropDownItem} from "../components/dropdown"

interface IWorkoutSectionProps {
    title?: string;
    sectionType?: SectionType;
    measureType?: SectionMeasureType;
    time?: string;
    active?: boolean;
    onTitleChanged?: (title : string) => void
}

interface IWorkoutSectionStats {
    sectionType : string;
    measureType: string;
}

export class WorkoutSection extends React.Component <IWorkoutSectionProps,IWorkoutSectionStats> {
    state : IWorkoutSectionStats = {} as IWorkoutSectionStats;

    constructor(props) {
        super(props);
        this.setSectionType = this.setSectionType.bind(this);
        this.setMeasureType = this.setMeasureType.bind(this);
     }
    componentDidMount() {
        var sectionType = SectionType[this.props.sectionType?this.props.sectionType:SectionType.Order].toLowerCase();
        var measureType = SectionMeasureType[this.props.measureType?this.props.measureType:SectionMeasureType.Rounds].toLowerCase();

        this.setState({sectionType: sectionType, measureType:measureType})
    }

    setSectionType(sectionType : string) {
        this.setState({sectionType: sectionType})
    }
    setMeasureType(measureType : string) {
        this.setState({measureType: measureType})
    }

    getSectionIcon(type:string) : string {
        var item =  SectionTypeOptions.find(x=>x.id == type);
        return item?item.icon :"";
    }

    getClass(isActive : boolean) : string {
        return "collapsible-header blue-grey white-text" + (isActive
            ? " active"
            : "");
    }

    render() {
        return <li>
            <div
                className={this.getClass(this.props.active)}
                style={{
                "display": "block"
            }}>
                <div className="row">
                    <div className="valign-wrapper col s12">
                        <i className="material-icons">{this.getSectionIcon(this.state.sectionType)}</i>
                        <span>{this.props.title}</span>
                        <div className="right valign-wrapper">
                            <i className="material-icons prefix">access_time</i>
                            {this.props.time}
                        </div>
                    </div>

                </div>
            </div>
            <div className="collapsible-body no-padding">
                <div className="row">
                    <div className="input-field col s12">
                        <input type="text" id="section_header" value={this.props.title}/>
                        <label htmlFor="section_header">Section Title</label>
                    </div>
                </div>
                <div className="row blue-grey lighten-5">
                    <div className="col s12 valign-wrapper input-field">
                        Play exercises in
                        <div className="inline">
                            <DropDown
                                value={this.state.sectionType}
                                onChange={this.setSectionType}
                                items={SectionTypeOptions}/>
                        </div>
                        measuring
                        <div className="inline">
                             <DropDown
                                value={this.state.measureType}
                                onChange={this.setMeasureType}
                                items={SectionMeasureTypeOptions}/>
                        </div>
                        in &nbsp;&nbsp;&nbsp;
                       {this.state.measureType == SectionMeasureType[SectionMeasureType.Time].toLowerCase() &&
                       <div>
                            <div className="input-field inline">
                                <input type="number" id="minutes"/>
                                <label htmlFor="minutes">Minutes</label>
                            </div>&nbsp;
                            <div className="input-field inline">
                                <input type="number" id="seconds"/>
                                <label htmlFor="seconds">Seconds</label>
                            </div>
                        </div>
                       }
                       

                    </div>
                </div>
            </div>
        </li>

    }
}

export enum SectionType {
    Order,
    Circuit
}

const SectionTypeOptions : IDropDownItem[] = [
    {
        id: "circuit",
        title: "circuit",
        icon: "autorenew"
    }, {
        id: "order",
        title: "order",
        icon: "list"
    }
]

export enum SectionMeasureType {
    Distance,
    Time,
    Rounds
}

const SectionMeasureTypeOptions : IDropDownItem[] = [
    {
        id: "distance",
        title: "distance",
        icon: "linear_scale"
    }, {
        id: "time",
        title: "time",
        icon: "access_time"
    },
    {
        id: "rounds",
        title: "rounds",
        icon: "format_list_numbered"
    }
]