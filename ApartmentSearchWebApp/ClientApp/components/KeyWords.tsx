import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as ApartmentStore from '../store/Apartments';


type KeyWordProps = ApartmentStore.IApartmentStore
    & typeof ApartmentStore.actionCreators
    & RouteComponentProps<{}>;

class KeywordList extends React.Component<KeyWordProps, {}>
{
    public render() {
        <ul>
            props.keyWords.map((current, index) => {
                return <KeywordItem Keyword={current} />; 
            }             
        </ul>
    }
}

function KeywordItem(props: any) {
    return <li>Keyword: {props.Keyword}</li>;
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.apartments,
    ApartmentStore.actionCreators
)(KeywordList) as typeof KeywordList;