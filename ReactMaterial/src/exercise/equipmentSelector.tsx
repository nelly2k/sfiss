import * as React from "react";

interface IEquipmentSelector{
    onChange?:(values:string[])=>void
}
export class EquipmentSelector extends React.Component<IEquipmentSelector> {
    selected:string[] = [];
    constructor(props) {
        super(props);
        this.handleSelecton = this.handleSelecton.bind(this);
    }
   componentDidMount() {
        var component = this;
         $(this.refs.equipmentSelector).on('change', function (event) {
            component.handleSelecton(event);
        }).material_select();
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
    render() {
        return <div className="input-field">
            <select ref="equipmentSelector" multiple className="icons">
                <option value="barbell" data-icon="media/barbell.jpg" >Barbell</option>
                <option value="ball" data-icon="media/medicineball.jpg">Ball</option>
                <option value="kettlebell" data-icon="media/kettlebell.jpg">Kettlebell</option>
            </select>
             <label>Equipment</label>
        </div>
    }
}