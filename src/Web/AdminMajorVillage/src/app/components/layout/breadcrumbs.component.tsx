import { Breadcrumbs } from "@mui/material";
import React from "react"
import { useMatches, Link } from "react-router-dom";

const BreadCrumbsComponent: React.FC = () => {
    let matches = useMatches();
    let crumbs = matches
    matches.filter((match: any) => Boolean(match.handle?.crumb))
        .map((match: any) => match.handle.crumb(match.data));

    return (
        <div role="presentation">
            <Breadcrumbs aria-label="breadcrumb">
                {crumbs.map((crumb: any, index) => (
                    <Link key={index} color="inherit" style={{textDecoration: 'none'}} aria-disabled={true} to={crumb.pathname}>{`${crumb?.handle?.infos.title}`}</Link>
                ))}
            </Breadcrumbs>
        </div>
    );
}

export default BreadCrumbsComponent;