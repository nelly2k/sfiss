import * as React from "react";

interface IMultiSelectorProprs{
    onChange?:(values:string[])=>void;
    selectedIds: string[];
    data:IMultiSelectItem[],
    label:string
}
export interface IMultiSelectItem {
    id:string;
    title:String;
}

export class MultiSelect extends React.Component<IMultiSelectorProprs> {
    selected:string[] = [];
    constructor(props) {
        super(props);
        this.handleSelecton = this.handleSelecton.bind(this);
    }
    
    componentDidMount() {
        var component = this;
         $(this.refs.multiSelector).on('change', function (event) {
            component.handleSelecton(event);
        }).material_select();
    }

    componentDidUpdate(){
         $(this.refs.multiSelector).material_select();
    }

    handleSelecton(event){
        this.selected = new Array();
        for(var i = 0;i<event.target.options.length;i++){
            var item = event.target.options[i];
              if (item.selected){
                 this.selected.push(item.value);
            }
        }
        if (this.props.onChange){
            this.props.onChange(this.selected);
        }
    }

    handleChange(e){
    }

    render() {
        return <div className="input-field">
            <select ref="multiSelector" multiple className="icons" value={this.props.selectedIds} onChange={this.handleChange}> 
                <option value="" disabled>Choose your options</option>
                {this.props.data.map(et=><option key={et.id} value={et.id}>{et.title}</option>)}
            </select>
             <label>{this.props.label}</label>
        </div>
    }
}
